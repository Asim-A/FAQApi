// Array av klasser "promotional-block" (div), alle de har en anchor med klasse "EPiLink" som inneholder href

let promotional_divs = document.getElementsByClassName("promotion-block-text");
let categories = [];

const defaultLink = "https://www.vy.no/";

for (var i = 0; i < promotional_divs.length; i++) {
  const anc = promotional_divs[i].getElementsByClassName("EPiLink")[0];
  const href = anc.getAttribute("href");
  const span = anc.getElementsByClassName("typography-heading-2")[0];

  const question = {
    question_body: span.innerHTML.trim(),
    question_link: href
  };

  categories.push(question);
}

let questions = [];

for (var i = 0; i < categories.length; i++) {
  const href = categories[i]["question_link"];
  const link = defaultLink + href;

  response_html = await getQuestions(link);

  response_html = response_html.then();
}

async function getQuestions(url) {
  const response = fetch(url).then(res => {
    return res.text();
  });
}

async function makeQuestions(html, question_array) {}
