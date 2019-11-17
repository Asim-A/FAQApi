import React, { Component } from "react";
import Accordion from "./Accordion";
import Subcategory from "./Subcategory";

class Categories extends Component {
  constructor(props) {
    super(props);

    this.state = {
      category: []
    };
  }

  createAccordions = questions => {
    return (
      <div>
        {questions.map(question => (
          <Accordion
            key={question.question_id}
            question_body={question.question_body}
            answer={question.answer}
          ></Accordion>
        ))}
      </div>
    );
  };

  createSubcategories = subcategories => {
    return (
      <div className="subcategory-wrapper">
        {subcategories.map(subs => (
          <Subcategory
            key={subs.subcategory_id}
            id={subs.subcategory_id}
            title={subs.subcategory_title}
          ></Subcategory>
        ))}
      </div>
    );
  };

  componentDidMount = () => {
    let id = this.props.match.params.id;
    console.log("id:" + id);

    fetch("https://localhost:44382/v1/faq/categories/" + id)
      .then(res => res.json())
      .then(json => {
        this.setState({ category: json });
        console.log("CATEGORY:");
        console.log(this.state.category);
        console.log("CATEGORY END");
      });
  };

  render() {
    let myObj = this.state.category;

    if (myObj.length === 0) return <h1></h1>;

    let subcategories = myObj[0].Subcategories;

    return this.createSubcategories(subcategories);
  }
}

export default Categories;
