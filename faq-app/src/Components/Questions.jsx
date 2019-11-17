import React, { Component } from "react";
import Accordion from "./Accordion";

class Questions extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Questions: []
    };
  }

  componentDidMount() {
    fetch(
      "https://localhost:44382/v1/faq/questions/bySubcategory?id=" +
        this.props.sub_id
    )
      .then(res => res.json())
      .then(json => {
        this.setState({ Questions: json });
        console.log("SUBCATEGORY " + this.props.sub_id + " QUESTIONS");
        console.log(this.state.Questions);
        console.log("QUESTIONS END");
      });
  }

  createQuestions = Questions => {
    return (
      <div className="question-wrapper">
        {Questions.map(question => (
          <div className="question">
            <Accordion
              key={question.question_id}
              question_body={question.question_body}
              answer={question.answer}
            ></Accordion>
          </div>
        ))}
      </div>
    );
  };

  render() {
    if (this.state.Questions.length === 0) return <h1>SORRY PLEASE WAIT</h1>;
    return this.createQuestions(this.state.Questions);
  }
}

export default Questions;
