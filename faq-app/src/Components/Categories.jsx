import React, { Component } from "react";
import Subcategory from "./Subcategory";
import "../Categories.css";
import { Link } from "react-router-dom";

class Categories extends Component {
  constructor(props) {
    super(props);

    this.state = {
      category: []
    };
  }

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

    fetch("/v1/faq/categories/" + id)
      .then(res => res.json())
      .then(json => {
        this.setState({ category: json });
      });
  };

  render() {
    let myObj = this.state.category;

    if (myObj.length === 0) return <h1>LASTER</h1>;

    //vet hvis myObj ikke er tom så er det akkurat 1 subcat, mtp. backend.
    let category = myObj[0];

    let subcategories = category.Subcategories;

    return (
      <div className="category">
        <h1>{category.category_title}</h1>
        <h4 className="cathead">{category.category_body}</h4>

        <Link to="/nytt-spørsmål">
          Hvis du ikke finne svar på spørsmålet ditt kan du kontakte oss her
        </Link>

        {this.createSubcategories(subcategories)}
      </div>
    );
  }
}

export default Categories;
