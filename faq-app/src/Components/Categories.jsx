import React, { Component } from "react";

class Categories extends Component {
  constructor(props) {
    super(props);

    this.state = {
      category: []
    };
  }

  componentDidMount = () => {
    let id = this.props.match.params.id;
    console.log("id:" + id);

    fetch("https://localhost:44382/v1/faq/categories/" + id)
      .then(res => res.json())
      .then(json => {
        this.setState({ category: json });
        console.log(this.state.category);
      });
  };

  render() {
    let myObj = this.state.category;

    if (myObj.length === 0) return <h1>HAHAHAHAH</h1>;

    return <h2>lol</h2>;
  }
}

export default Categories;
