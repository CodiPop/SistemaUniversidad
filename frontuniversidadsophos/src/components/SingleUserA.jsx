import React from "react";
import {
  Box,
  Button,
  Card,
  CardContent,
  CardMedia,
  Typography,
} from "@mui/material";
import { makeStyles } from "@material-ui/core/styles";
import { Link } from "react-router-dom";
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
  , numDocumento, fechaNacimiento, idCurso,idCursoPrerrequisitoNavigation}) => {

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
    </CardContent>

  </Card>

    
  );
};

export default SingleUserA;
