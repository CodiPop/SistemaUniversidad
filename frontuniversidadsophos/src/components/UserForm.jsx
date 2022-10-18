import { FormControl, FormHelperText, InputLabel, Input, Box, Button } from "@mui/material";
import axios from "axios";
import React from "react";
import {useNavigate} from "react-router-dom"
import "./Styles/UserForm.css";

const UserForm = (props) => {
  const { name, pais, correo,id } = props.user;
const navigate = useNavigate()
  const handleSubmit = async(e) => {
    e.preventDefault()
    console.log(props.user)
    try {
      await axios.post("http://localhost:3000/users",props.user)
      navigate("/Lista")

    } catch (error) {
      console.log(error)
    }
    
  }

  const handleEdit = async() =>{
    try {
      await axios.put("http://localhost:3000/users/"+id,props.user)
      navigate("/Lista")

    } catch (error) {
      console.log(error)
    }
  }
  return (
    <div>
      <form className="form" onSubmit={handleSubmit}>
        <FormControl fullWidth>
          <InputLabel>Nombre:</InputLabel>
          <Input
            type="text"
            name="name"
            onChange={props.onChange}
            value={name}
          ></Input>
          <FormHelperText>Soy un mensaje de ayuda</FormHelperText>
        </FormControl>
        <br></br>
        <br></br>

        <FormControl fullWidth>
          <InputLabel>Pais:</InputLabel>
          <Input
            type="text"
            name="pais"
            onChange={props.onChange}
            value={pais}
          ></Input>
        </FormControl>
        <br></br>
        <br></br>
        <FormControl fullWidth>
          <InputLabel>Correo:</InputLabel>
          <Input
            type="text"
            name="correo"
            onChange={props.onChange}
            value={correo}
          ></Input>
        </FormControl>
        <Box align="center">
          {props.isEdit ? <Button onClick={handleEdit} color="primary" variant="container">Editar</Button>:<Button type="submit" color="primary" variant="container">Crear</Button>}
          
        </Box>
      </form>
    </div>
  );
};

export default UserForm;
