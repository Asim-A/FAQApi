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
const heading2 = "Heading--h2";
const heading3 = "Heading--h3";
// lagres som qa[0-9].json
function getTextFromButton(s) {
  return s.childNodes[0].innerText;
}

function getTextFromDiv(input) {
  return input.childNodes[2].innerHTML;
}

function getQuestions(subCat) {
  let questions = [];

  const allQs = subCat.getElementsByClassName(heading3);

  for (var i = 0; i < allQs.length; i++) {
    const mySpan = allQs[i];
    const mySpan_parent = mySpan.parentNode;

    const q = getTextFromButton(mySpan);

    const a = getTextFromDiv(mySpan_parent);

    questions.push({
      question_body: q,
      answer: a
    });
  }

  return questions;
}

function getAllSubCatNodes() {
  let nodes = [];

  let h = document.getElementsByClassName(heading2);

  for (let i = 0; i < h.length; i++) {
    nodes.push(h[i].parentNode);
  }

  return nodes;
}

function getSubCatText(parent) {
  const subText = parent.getElementsByClassName(heading2)[0].innerText;
  return subText;
}

function getJson() {
  let subcategories = [];
  let parent = getAllSubCatNodes();

  if (parent.length === 0) {
    const subcatTitle = "";
    const qs = getQuestions(document);

    subcategories.push({
      subcategory_title: subcatTitle,
      Questions: qs
    });
  } else {
    for (let i = 0; i < parent.length; i++) {
      const subcatTitle = getSubCatText(parent[i]);
      const qs = getQuestions(parent[i]);

      subcategories.push({
        subcategory_title: subcatTitle,
        Questions: qs
      });
    }
  }

  let myJSON = JSON.stringify(subcategories);
  console.log(myJSON);
}

// slutt qa
