Backend:

Her har jeg valgt å bruke .net core 3.0 med entity framework core. For å oppnå en dynamisk trestruktur har jeg valgt å dele inn spørsmål og svar inn i underkategorier (subcategories) som igjen er delt inn i kategorier. 

Databasen består av Category, Subcategory, Question og CustomerQuestion. Det er slik at en kategori kan ha flere underkategorier, som igjen kan ha flere spørsmål. For å kommunisere med databasen er det laget et FAQContext. Alt som omhandler spørsmål og svar vil ligge i denne konteksten. CustomerQuestion har ingen forhold til de andre tabellene, men det tilhører likevel FAQ delen av api-et og derfor er det i samme context.

Det var ikke nødvendig å lagdele løsnininge, men jeg har implementert repository pattern i løsningen. Hensikten med repo-pattern er innkaplse logikken som håndterer spørringene mot databasen, i essens tilsvarer dette samme fordeler som ved lagdeling. Hver tabell har sin egen repository gitt med navnet på tabellen + repository (e.g. CategoryRepository). Disse arver fra "Repository : IRepository" der alle generelle spørringer blir grensesnittet. 

Tabellene sine egene repositorier utvider implementasjonen av logikken som gjør spørringer og der har jeg skreddersydde metoder som er aktuelle for oppgaven, f.eks. GetWithQuestionID, GetAllIncludedJSON, GetQuestionsBySubcategory. Man bruker repositoriene ved UnitOfWork klassen som har en instanse av alle repositoriene.

Grunnen til at jeg gjorde det på denne måten var fordi det var enklere enn lagdeling, men ga samme fordeler. Dette førte til at løsningen er veldig strukturert samt enkel å utvide. Jeg gjorde det også fordi jeg enhetstestet løsningen, og da kan man bare dependency injecte stub istedet for databasen, minket startup tid for programmet samt gjorde testing raskere.

Per RESTful api konvensjoner (https://restfulapi.net/) har jeg tildelt hver entitet sin egen kontroller, samt laget de nødvendige CRUD operasjonen som metoder (actions). Jeg har gjort standard route som "v1/faq/{controller}". Jeg har bare laget aktuelle api-kall, men, alle enkle api-kall er laget i repositoriene, så det er bare å lage metoden for api-kallet i kontrollerne så vil det funke.

Jeg valgte å ikke bruke data transfer objects fordi jeg konkluderte at databasemodellene ikke holdt sensetiv informasjon. Hvis det noen sinne skulle være grunn til å bruke DTOs kan man i repositoryene kartlegge (map) verdiene som er hensiktsmessige enkelt til et DTO og returnere json versjonen av det. 

For å vise at løsningen min har substans har jeg valgt å webscrape vy sine kategorier, underkategorier, spørsmål og svar. Disse har jeg gjort med JSUtility/VyDataScraper.js som jeg lagde selv. Her blir de aktuelle dataene kartlagt til json med data felt som har samme navn som data feltene i database modellene. Ved å passe på at data-en i json format framstilles som databasen så kan man deserialisere json objektene om til databasemodeller. Jeg brukte denne artikkelen: "https://thedatafarm.com/data-access/seeding-ef-with-json-data/". I Database/Seeder.cs skjer deserialiseringen, det blir dependency injecta FAQContext i startup sin serviceconfig og Seeder vil så fylle databasen (hvis den er tom) med json-data.

Et rating system er laget, og api-kall (request) til /v1/faq/questions/{id} + question objektet i body (IKKE URI) med endret question_likes og/eller question_dislikes vil endre raden i tabellen. Jeg rakk ikke å implementere dette frontend messig, men hvis du har postman kan du teste dette om du ønsker. 

UnitOfWork har en dispose metode, jeg leste at å bruke using er tregere enn å dispose ressursen når den er ferdig. Jeg gjorde 100000 iterasjoner på mitt nest største objekt for å teste påstanden. I løsningen er to png filer av sammenlignelse mellom using og dispose på 1000 iterasjoner. Der var dispose 15% raskere. 

Validering av CustomerQuestion objektet skjer både frontend og backend. Hvis noen poster en ugyldig request vil de få 400 bad request response med melding om hva som er feil. Feilen er ikke displayet frontend fordi frontend validation forsørger at det ikke burde hende. Men hvis du bruker postman eller lignende vil du få meldingen.

Hvis du har postman, curl, browser devtool eller lignende og vil teste api-et så anbefaler jeg disse kallene:

Henter alle kategori uten underkategorier:
GET: /v1/faq/categories/

Henter kategori med id (der id kan være int fra 1-6 ifølge seed), returnerer kategorien MED underkategorier og spørsmål:
GET: /v1/faq/categories/{id}

Henter alle kategoriene & deres underkategorier & spørsmål. Dette tilsvarer JSUtility/category1.json filen som ble brukt til å seede. Dette api-kallet ble brukt for å teste database.
GET: /v1/faq/categories/GetAll

Henter spørsmål tabellen.
GET: /v1/faq/question/           

Henter spørsmål m/id
GET: /v1/faq/question/{id}   

Endrer rad til den id-en. Man må legge til body i put-requesten. 
PUT: /v1/faq/question/id

Må ha body med riktig objekt, legger ting i CustomerQuestion tabellen.
POST: /v1/faq/CustomerQuestions

Frontend:

Her valgte jeg å bruke React og bootstrap. Frontend prosjektet ligger i faq-app mappen. Jeg har laget aktuelle komponenter for å strukturere data som man får gjennom api-et. Styling er litt begrenset, men i hovedsak så burde alt være leselig og responsivt takket være bootstrap 4. 

Startsiden (/) vil ha kort med alle kategoriene. Når man trykker på en av kategoriene kommer man inn til en side som viser alle underkategoriene innen den kategorien. Deretter vil hver underkategori ha en liste av accordions, som vil inneholde spørsmålet, svaret (trykk) og hvor populært det er (synkende, mest populær først). Det går ikke an å endre verdien på likes frontend, men hvis du gjør et api-kall kan det bli endret. 

Alle kategorier kan lenke til ContactForm komponenten der man kan sende inn spørsmål. 

Jeg innser at frontend krever endel styling, men jeg mener det er stortsett funksjonelt.

Ting som mangles:
1. Alternativ måte å sortere spørsmål, bare etter mest populært (frontend).
2. Binde opp og ned knappene til å gjøre api-kall på put metoden i questionscontroller
