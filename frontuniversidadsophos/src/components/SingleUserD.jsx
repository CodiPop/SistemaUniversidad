import React from "react";
import {
  Button,
  Card,
  CardContent,
  Typography,
} from "@mui/material";
import { makeStyles } from "@material-ui/core/styles";
import { Link as RLink} from "react-router-dom";
import axios from "axios";
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

export const SingleUserD = ({ nombreDocente,numDocumento, fechaNacimiento, nombreNivelAcademico,idDocente}) => {

  const classes = useStyle();
  const handleClick = async() =>{
    try {

      await axios.delete("https://localhost:44351/api/docentes/"+idDocente)
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
        {nombreDocente}
      </Typography>
      <Typography variant="body1">
        <strong>Nivel Academico: </strong>
        {nombreNivelAcademico}
      </Typography>
      <Typography variant="body1">
        <strong>Numero de documento: </strong>
        {numDocumento}
      </Typography>
      <Typography variant="body1">
        <strong>Fecha de Nacimiento: </strong>
        {fechaNacimiento}
      </Typography>
      <Button component={RLink} to="/EditD" state={{id: idDocente}}>Editar</Button>
      <Button color="error" onClick={handleClick}>Eliminar</Button>
    </CardContent>

  </Card>

    
  );
};

export default SingleUserD;
