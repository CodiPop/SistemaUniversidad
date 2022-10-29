import React, {useEffect, useState} from 'react'
import axios from 'axios'
import SingleUser from './SingleUser';
import SingleUserA from './SingleUserA';
import SingleUserD from './SingleUserD';
import { Box,Button,Grid } from '@mui/material';
import "./Styles/List.css"
import{Link as RLink} from "react-router-dom";
const List = () => {
    const [cursos,setCursos] = useState([]);
    const [alumnos,setAlumnos] = useState([]);
    const [docentes,setDocentes] = useState([]);
    const [niveles,setNiveles] = useState([]);
    const getData = async () => {

        

        try {
            
            const responseC = await axios.get("https://localhost:44351/api/cursos")
            const responseA = await axios.get("https://localhost:44351/api/alumnos")
            const responseD = await axios.get("https://localhost:44351/api/docentes")
            const responseN = await axios.get("https://localhost:44351/api/NivelAcademicoes")
            //console.log(responseC.data);
            //const { results } = responseC.data;
            console.log(responseC.data);
            console.log(responseA.data);
            console.log(responseD.data);
            console.log(responseN.data);
            setCursos(responseC.data);
            setAlumnos(responseA.data);
            setDocentes(responseD.data);
            setNiveles(responseN.data);
            
            
        } catch (error) {
            console.log(error);
        }
    }

        useEffect (() => {
            getData()
        },[])

  return (

        
      <div >

<Box sx={{ flexGrow: 1 }}>
      <Grid container spacing={3}>
        <Grid item xs={4}>

        <div className='center'><h3>Cursos</h3></div>
        <Box >
        <Box textAlign='center'>
        <Button component={RLink} to="/Create" variant='contained' className='center' state={{ es : "curso"}}>Crear</Button>
        </Box>
        {cursos.map((item,index) => (
        <SingleUser key={index} {...item} isEdit />
        ))}
        </Box>
        </Grid>
        <Grid item xs={4}>
        <div className='center'><h3>Alumnos</h3></div>
        <Box>
        <Box textAlign='center'>
        <Button component={RLink} to="/Create" variant='contained' className='center' state={{ es : "alumno"}}>Crear</Button>
        </Box>
        {alumnos.map((item,index) => (
        <SingleUserA key={index} {...item} isEdit/>
        ))}
        </Box>
        </Grid>
        <Grid item xs={4}>
        <div className='center'><h3>Profesores</h3></div>
        <Box>
        <Box textAlign='center'>
        <Button component={RLink} to="/Create" variant='contained' className='center' state={{ es : "docente"}}>Crear</Button>
        </Box>

        {docentes.map((item,index) => (
            
        <SingleUserD key={index} {...item} cadenaA isEdit/>
        ))}
        </Box> 
        </Grid>
      </Grid>
    </Box>
        
            
        
  
      </div>
  );
};

export default List