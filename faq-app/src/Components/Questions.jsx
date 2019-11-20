import React, { Component } from "react";
import Accordion from "./Accordion";
import "../Questions.css";
import Chevron from "./Chevron";

class Questions extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Questions: []
    };
  }

  componentDidMount() {
    fetch("v1/faq/questions/bySubcategory?id=" + this.props.sub_id)
      .then(res => res.json())
      .then(json => {
        this.setState({ Questions: json });
      });
  }

  createQuestions = Questions => {
    return (
      <div className="question-wrapper">
        {Questions.map(question => (
          <div key={question.question_id} className="question">
            <div className="upvote">
              <Chevron
                className="chev rotateleft"
                height={10}
                width={10}
              ></Chevron>
              <div className="likes">{question.question_likes}</div>
              <Chevron
                className="chev rotateright"
                height={10}
                width={10}
              ></Chevron>
            </div>

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
