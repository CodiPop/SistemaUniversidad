import React from "react";
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

  const classes = useStyle();

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
    </CardContent>

  </Card>

    
  );
};

export default SingleUserA;
