import React, {useEffect}from "react";
import { useGetMore2 } from "../hooks/useGetMore2";
import {
  Button,
  Card,
  CardContent,
  Typography,
} from "@mui/material";
import { Link as RLink} from "react-router-dom";
import { makeStyles } from "@material-ui/core/styles";
import axios from "axios";
import Modal from "./Modal";
const useStyle = makeStyles({
  cardUser: {

    width: "80%",
    margin: "8px auto",

  },

  cardMedia: {
    
  },
  carContent: {
    
  },
  actions: {

  }
});

export const SingleUserA = ({ nombreAlumno, facultad
  , numDocumento, fechaNacimiento, idAlumno}) => {
  const classes = useStyle();
  const handleClick = async() =>{

    try {
      await axios.delete("https://localhost:44351/api/InscripcionesCursoes/delete/"+idAlumno)
      console.log("borre la inscripcion")
    } catch (error) {
      
    }
    try {
      await axios.delete("https://localhost:44351/api/alumnos/"+idAlumno)
      
      window.location.reload(false);
    } catch (error) {
      console.log(error)
    }
  }

  const {data2,addData2 } = useGetMore2();
  const {data3,addData3 } = useGetMore2();
  const getData = async () => {
    const response = await axios.get(
      "https://localhost:44351/api/Alumnos/CursoInfo/" + idAlumno
    );
    const { data } = response;
    
      const {acumulado}=data
      const {cursos} = data
      
    addData2(acumulado)
    addData3(cursos)

    
  };

  useEffect(() => {
    getData();
  }, []);
  return (
    <Card className={classes.cardUser}>
    <CardContent className={classes.carContent}>
      <Typography variant="body1">
        <strong>Nombre: </strong>
        {nombreAlumno}
      </Typography>
      <Typography variant="body1">
        <strong>Facultad: </strong>
        {facultad}
      </Typography>
      <Typography variant="body1">
        <strong>Numero de documento: </strong>
        {numDocumento}
      </Typography>
      <Typography variant="body1">
        <strong>Fecha de Nacimiento: </strong>
        {fechaNacimiento}
      </Typography>
      <Button component={RLink} to="/EditA" state={{id: idAlumno}}>Editar</Button>
      <Button color="error" onClick={handleClick}>Eliminar</Button>
      <Modal info={data2} info2={data3}  getData={getData}></Modal>
    </CardContent>

  </Card>

    
  );
};

export default SingleUserA;
