// Array av klasser "promotional-block" (div), alle de har en anchor med klasse "EPiLink" som inneholder href

// Lagres som categories.json
const defaultLink = "https://www.vy.no/";

function setupCategories() {
  let promotional_divs = document.getElementsByClassName(
    "promotion-block-text"
  );
  let categories = [];

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
}
// categories.json slutt

// lagres som qa[0-9].json
function getTextFromButton(s) {
  return s.childNodes[0].innerText;
}

function getTextFromDiv(input) {
  return input.childNodes[2].innerHTML;
}

function setupQuestions(questions, headings) {
  for (var i = 0; i < headings.length; i++) {
    const mySpan = headings[i];
    const mySpan_parent = mySpan.parentNode;

    const q = getTextFromButton(mySpan);

    const a = getTextFromDiv(mySpan_parent);

    questions.push({
      question: q,
      answer: a
    });
  }
}

function getJson() {
  let questions = [];
  let headings = document.getElementsByClassName("Heading--h3");

  setupQuestions(questions, headings);
  let myJSON = JSON.stringify(questions);
  console.log(myJSON);
}

// slutt qa
