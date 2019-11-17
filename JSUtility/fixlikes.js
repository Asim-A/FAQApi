myJson = [];

function fix(myJson) {
  for (var i = 0; i < myJson.length; i++) {
    let sub_array = myJson[i].Subcategories;

    for (var j = 0; j < sub_array.length; j++) {
      let questions = sub_array[j].Questions;

      for (var k = 0; k < questions.length; k++) {
        questions[k].likes = getRandomInt(0, 9999);
      }
    }
  }
}

function getRandomInt(min, max) {
  min = Math.ceil(min);
  max = Math.floor(max);
  return Math.floor(Math.random() * (max - min + 1)) + min;
}
