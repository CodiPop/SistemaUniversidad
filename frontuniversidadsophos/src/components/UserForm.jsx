import { FormControl, FormHelperText, InputLabel, Input, Box, Button } from "@mui/material";
import axios from "axios";
import React from "react";
import {useNavigate} from "react-router-dom"
import "./Styles/UserForm.css";

const UserForm = (props) => {
const { nombreCurso, numCreditos, cupos,idCurso, idCursoPrerrequisito } = props.user;
const navigate = useNavigate()
  const handleSubmit = async(e) => {
    e.preventDefault()
    console.log(props.user)
    try {
      await axios.post("https://localhost:44351/api/cursos",props.user)
      navigate("/")

    } catch (error) {
      console.log(error)
    }
    
  }

  const handleEdit = async() =>{
    try {

      await axios.put("https://localhost:44351/api/cursos/"+idCurso,props.user)
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
            name="nombreCurso"
            onChange={props.onChange}
            value={nombreCurso}
          ></Input>
          
        </FormControl>
        <br></br>
        <br></br>
        <FormControl fullWidth>
          <InputLabel>Prerrequisito:</InputLabel>
          <Input
            type="text"
            name="idCursoPrerrequisito"
            onChange={props.onChange}
            value={idCursoPrerrequisito}
          ></Input>
          <FormHelperText>Id del curso prerrequisito</FormHelperText>
        </FormControl>
        <br></br>
        <br></br>

        <FormControl fullWidth>
          <InputLabel>Numero de Creditos:</InputLabel>
          <Input
            type="text"
            name="numCreditos"
            onChange={props.onChange}
            value={numCreditos}
          ></Input>
        </FormControl>
        <br></br>
        <br></br>
        <FormControl fullWidth>
          <InputLabel>Cupos:</InputLabel>
          <Input
            type="text"
            name="cupos"
            onChange={props.onChange}
            value={cupos}
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
