import React from "react";
import {useNavigate} from "react-router-dom"
import {
  Box,
  Button,
  Card,
  CardContent,
  CardMedia,
  Typography,
} from "@mui/material";
import { Link as RLink} from "react-router-dom";
import { makeStyles } from "@material-ui/core/styles";
import axios from "axios";
import { Container } from "@mui/system";
const useStyle = makeStyles({
  cardUser: {

    width: "50%",
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
  const navigate = useNavigate()
  const classes = useStyle();
  const handleClick = async() =>{
    try {

      await axios.delete("https://localhost:44351/api/alumnos/"+idAlumno)
      window.location.reload(false);
      

    } catch (error) {
      console.log(error)
    }
  }
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
    </CardContent>

  </Card>

    
  );
};

export default SingleUserA;
