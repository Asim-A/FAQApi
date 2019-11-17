import React, { Component } from "react";
import "../ContactForm.css";

class ContactForm extends Component {
  state = {
    email: "",
    question: "",
    emailError: "",
    questionError: ""
  };

  validateEmail(email) {
    var re = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    return re.test(String(email).toLowerCase());
  }

  validate = () => {
    let emailError = "";
    let questionError = "";

    if (!this.validateEmail(this.state.email)) {
      emailError = "Eposten er ugyldig.";
    }

    if (!this.state.question) {
      this.questionError = "Du må skrive inn noe!";
    }

    if (emailError || questionError) {
    }
  };

  handleSubmit = event => {
    event.preventDefault();

    const isValid = this.validate();
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
            <form className="form-wrapper">
              <div className="input-wrapper">
                <label htmlFor="cemail">Epost:</label>
                <input
                  className="form-control"
                  type="text"
                  id="cemail"
                  name="customer_email"
                  placeholder="Kari_Nilsen@hotmail.no"
                />
              </div>
              <div className="input-wrapper">
                <label htmlFor="cquestion">Spørsmål:</label>
                <input
                  className="form-control"
                  type="text"
                  id="cquestion"
                  name="customer_question"
                  placeholder="Hvordan kjøper man billett?"
                />
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
