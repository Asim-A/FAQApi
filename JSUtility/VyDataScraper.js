// Array av klasser "promotional-block" (div), alle de har en anchor med klasse "EPiLink" som inneholder href

let promotional_divs = document.getElementsByClassName("promotion-block-text");
let questions = [];

for (var i = 0; i < promotional_divs.length; i++) {
  const anc = promotional_divs[i].getElementsByClassName("EPiLink")[0];
  const href = anc.getAttribute("href");
  const span = anc.getElementsByClassName("typography-heading-2")[0];

  const question = {
    question_body: span.innerHTML.trim(),
    question_link: href
  };

  questions.push(question);
}

async function getQuestions() {
  const response = fetch(
    "https://www.vy.no/kundeservice/sporsmal-og-svar"
  ).then(res => {
    return res.text();
  });
}
