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

export const SingleUser = ({ nombreCurso, idCursoPrerrequisito
  , numCreditos, cupos, idCurso,idCursoPrerrequisitoNavigation}) => {

  const classes = useStyle();

  return (
    <Card className={classes.cardUser}>
    <CardContent className={classes.carContent}>
      <Typography variant="body1">
        <strong>Nombre: </strong>
        {nombreCurso}
      </Typography>
      <Typography variant="body1">
        <strong>Prerrequisito: </strong>
        {idCursoPrerrequisitoNavigation?.nombreCurso}
      </Typography>
      <Typography variant="body1">
        <strong>Numero de creditos: </strong>
        {numCreditos}
      </Typography>
      <Typography variant="body1">
        <strong>Cupos: </strong>
        {cupos}
      </Typography>
    </CardContent>

  </Card>

    
  );
};

export default SingleUser;
