import React, { Component } from "react";
import "../ContactForm.css";

const initialState = {
  email: "",
  question: "",
  emailError: "",
  questionError: ""
};

class ContactForm extends Component {
  constructor(props) {
    super(props);
    this.state = initialState;

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }

  validate = () => {
    let emailError = "";
    let questionError = "";

    if (!this.validateEmail(this.state.email)) {
      emailError = "Eposten er ugyldig.";
    }

    if (
      this.state.question === "" ||
      this.state.question.length < 10 ||
      this.state.question.length > 512
    ) {
      questionError = "Du må skrive inn noe! Mellom 10-512 karakterer.";
    }

    if (emailError || questionError) {
      this.setState({ emailError, questionError });
      return false;
    }

    return true;
  };

  handleChange = event => {
    this.setState({ [event.target.name]: event.target.value });
  };

  handleSubmit = event => {
    event.preventDefault();

    const isValid = this.validate();

    if (isValid) {
      this.setState(initialState);
    }
  };

  render() {
    return (
      <div className="d-flex contact-wrapper">
        <div>
          <h1>Send inn ditt spørsmål!</h1>
          <p>
            Hvis FAQ siden vår manglet et spørsmål som du gjerne ønsker å få
            svar på kan du kontakte oss her.
          </p>
        </div>
        <div className="d-flex cf-wrapper">
          <div>
            <form className="form-wrapper" onSubmit={this.handleSubmit}>
              <div className="input-wrapper">
                <label>Epost:</label>
                <input
                  className="form-control"
                  type="text"
                  value={this.state.email}
                  onChange={this.handleChange}
                  name="email"
                  placeholder="Kari_Nilsen@hotmail.no"
                />
                <div style={{ fontSize: 12, color: "red" }}>
                  {this.state.emailError}
                </div>
              </div>
              <div className="input-wrapper">
                <label htmlFor="cquestion">Spørsmål:</label>
                <input
                  className="form-control"
                  type="text"
                  value={this.state.question}
                  onChange={this.handleChange}
                  name="question"
                  placeholder="Hvordan kjøper man billett?"
                />
                <div style={{ fontSize: 12, color: "red" }}>
                  {this.state.questionError}
                </div>
              </div>

              <input className="btn btn-primary" type="submit" value="Submit" />
            </form>
          </div>
        </div>
      </div>
    );
  }
}

export default ContactForm;
