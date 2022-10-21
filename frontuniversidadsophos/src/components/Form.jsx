import React, {useState, useEffect } from 'react'
import { FormControl, FormHelperText, InputLabel, Input, Box, Button } from "@mui/material";
import { makeStyles } from "@material-ui/core/styles";
import axios from 'axios';
import {useNavigate} from "react-router-dom"


const intialState = {
    nombreCurso: "",
    numCreditos: "",
    cupos:"",
    idCursoPrerrequisito: "",
    idFacultad:""


  };
  

const useStyle = makeStyles({
    container: {
      display: "none",
     
      
    }})

export const Form = ({parametro}) => {
    const navigate = useNavigate()
    const [user, setUser] = useState(intialState);
const handleSubmit = async(e) => {
    e.preventDefault()
    console.log(user)
    try {
      await axios.post("https://localhost:44351/api/cursos/Insertar",user)
      navigate("/")

    } catch (error) {
      console.log(error)
    }
    
  }

  
    

    

      const handleChange = (e) => {
          setUser({ ...user, [e.target.name]: e.target.value });
        };
    const handleClick = (e) => {
            setUser({ ...user, [e.target.name]: e.target.value });
         };
    const classes = useStyle();
    console.log({parametro})

  return (
    <div>

<form className="form" >
{/* **************************     CURSOS          ***************************************** */}
        
          {parametro.es === "curso" ?<FormControl fullWidth>
          <InputLabel>Nombre del Curso:</InputLabel>
          <Input
            type="text"
            name="nombreCurso"
            onChange={handleChange}
            
          ></Input>
          <br></br>
        </FormControl>:<></>}
        

          {parametro.es === "curso" ?<FormControl fullWidth>
          <InputLabel>Id del curso Prerrequisito:</InputLabel>
          <Input
            type="text"
            name="idCursoPrerrequisito"
            onChange={handleChange}
          ></Input>
          <br></br>
          
        </FormControl>:<div className={classes.container}>    </div>}
        

          {parametro.es === "curso" ?<FormControl fullWidth>
          <InputLabel>Numero de creditos:</InputLabel>
          <Input
            type="text"
            name="numCreditos"
            onChange={handleChange}
          ></Input>
          <br></br>
        </FormControl>:<div className={classes.container}></div>}
        
          {parametro.es === "curso" ?<FormControl fullWidth>
          <InputLabel>Cupos:</InputLabel>
          <Input
            type="text"
            name="cupos"
            onChange={handleChange}
          ></Input>
          <br></br>
            
        </FormControl>:<div className={classes.container}></div>}
        {parametro.es === "curso" ?<FormControl fullWidth>
          <InputLabel>Id de la Facultad:</InputLabel>
          <Input
            type="text"
            name="idFacultad"
            onChange={handleChange}
          ></Input>
          <br></br>
            <Button onClick={handleSubmit}>Crear</Button>
        </FormControl>:<div className={classes.container}></div>}
        

{/* **************************        ALUMNOS       ***************************************** */}

          {parametro.es === "alumno" ?<FormControl fullWidth>
          <InputLabel>Nombre del Alumno:</InputLabel>
          <Input
            type="text"
            name="nombreAlumno"
          ></Input>
          <br></br>
        </FormControl>:<></>}

          {parametro.es === "alumno" ?<FormControl fullWidth>
          <InputLabel>Facultad:</InputLabel>
          <Input
            type="text"
            name="facultad"
          ></Input>
          <br></br>
        </FormControl>:<></>}

          {parametro.es === "alumno" ?<FormControl fullWidth>
          <InputLabel>Numero de documento:</InputLabel>
          <Input
            type="text"
            name="numDocumento"
          ></Input>
            <br></br>
        </FormControl>:<></>}

          {parametro.es === "alumno" ?<FormControl fullWidth>
          <InputLabel>Fecha de Nacimiento:</InputLabel>
          <Input
            type="text"
            name="fechaNacimiento"
          ></Input>
          <br></br>
        </FormControl>:<></>}


        {/* **************************        Docentes       ***************************************** */}

        
          {parametro.es === "docente" ?<FormControl fullWidth>
          <InputLabel>Nombre del Docente:</InputLabel>
          <Input
            type="text"
            name="mombreDocente"
          ></Input>
          <br></br>
        </FormControl>:false}

          {parametro.es === "docente" ?<FormControl fullWidth>
          <InputLabel>Nivel Academico:</InputLabel>
          <Input
            type="text"
            name="nivelAcademico"
          ></Input>
          <br></br>
        </FormControl>:false}

          {parametro.es === "docente" ?<FormControl fullWidth>
          <InputLabel>Numero de documento:</InputLabel>
          <Input
            type="text"
            name="numDocumento"
          ></Input>
          <br></br>
        </FormControl>:""}
 
            
          {parametro.es === "docente" ?<FormControl fullWidth>
          <InputLabel>Fecha de Nacimiento:</InputLabel>
          <Input
            type="text"
            name="fechaNacimiento"
          ></Input>
          <br></br>
        </FormControl>:false}
        
        
        
        
    </form>
    </div>
  )
}

export default Form