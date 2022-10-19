import { FormControl, FormHelperText, InputLabel, Input, Box, Button } from "@mui/material";
import axios from "axios";
import React from "react";
import {useNavigate} from "react-router-dom"
import "./Styles/UserForm.css";

const UserFormD = (props) => {
const { nombreDocente, numDocumento, idDocente,fechaNacimiento, nombreNivelAcademico } = props.user;
const navigate = useNavigate()
  const handleSubmit = async(e) => {
    e.preventDefault()
    console.log(props.user)
    try {
      await axios.post("https://localhost:44351/api/docentes",props.user)
      navigate("/")

    } catch (error) {
      console.log(error)
    }
    
  }

  const handleEdit = async() =>{
    try {

      await axios.put("https://localhost:44351/api/docentes/"+idDocente,props.user)
      navigate("/")

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
            name="nombreDocente"
            onChange={props.onChange}
            value={nombreDocente}
          ></Input>
          
        </FormControl>
        <br></br>
        <br></br>
        <FormControl fullWidth>
          <InputLabel>Facultad:</InputLabel>
          <Input
            type="text"
            name="nombreNivelAcademico"
            onChange={props.onChange}
            value={nombreNivelAcademico}
          ></Input>
        </FormControl>
        <br></br>
        <br></br>

        <FormControl fullWidth>
          <InputLabel>Numero de Documento:</InputLabel>
          <Input
            type="text"
            name="numDocumento"
            onChange={props.onChange}
            value={numDocumento}
          ></Input>
        </FormControl>
        <br></br>
        <br></br>
        <FormControl fullWidth>
          <InputLabel>Fecha de Nacimiento:</InputLabel>
          <Input
            type="text"
            name="fechaNacimiento"
            onChange={props.onChange}
            value={fechaNacimiento}
          ></Input>
        </FormControl>
        <Box align="center">
          {props.isEdit ? <Button onClick={handleEdit} color="primary" variant="container">Editar</Button>:<Button type="submit" color="primary" variant="container">Crear</Button>}
          
        </Box>
      </form>
    </div>
  );
};

export default UserFormD;
