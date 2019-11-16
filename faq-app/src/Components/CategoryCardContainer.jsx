import React, { Component } from "react";
import CategoryCard from "./CategoryCard";
import "../Category.css";

class CategoryCardContainer extends Component {
  constructor() {
    super();

    this.state = {
      categories: []
    };
  }

  categoryWrapper = cats => {
    return (
      <div className="d-flex category-wrapper">
        {cats.map(category => (
          <CategoryCard
            key={category.category_id}
            category_id={category.category_id}
            category_title={category.category_title}
          ></CategoryCard>
        ))}
      </div>
    );
  };

  /**
   * Kjører når react "fester" componenten til DOM. Her skjer et API kall
   */
  componentDidMount() {
    fetch("https://localhost:44382/v1/faq/categories")
      .then(res => res.json())
      .then(json => {
        this.setState({ categories: json });
      });
  }

  render() {
    if (!this.state.categories.length) return null;

    let cats = this.state.categories;

    return this.categoryWrapper(cats);
  }
}

export default CategoryCardContainer;
