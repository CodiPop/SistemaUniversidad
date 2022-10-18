import React from "react";
import "./Styles/Title.css"
import propTypes from "prop-types";

const Title = ({text}) =>{
    return(
        console.log(text),
        <h1 className="title">{text}</h1>
    )
}
Title.propTypes = {
     text: propTypes.string.isRequired
}

Title.defaultProps = {
    text : "defecto"
}

export default Title