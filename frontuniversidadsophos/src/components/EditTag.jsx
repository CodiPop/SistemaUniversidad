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

export const EditTag = ( props) => {
  console.log(props.user)
  const classes = useStyle();
  const intialState = {
    name:"abc",
    pais: "",
    correo: "",
  };
  return (
    <Card className={classes.cardUser}>
    <CardContent className={classes.carContent}>
      <Typography variant="body1">
        <strong>Nombre: </strong>
        {props.user.nombreCurso}
      </Typography>
      <Typography variant="body1">
        <strong>Prerrequisito: </strong>
        {props.user.idCursoPrerrequisito}
      </Typography>
      <Typography variant="body1">
        <strong>Numero de creditos: </strong>
        {props.user.numCreditos}
      </Typography>
      <Typography variant="body1">
        <strong>Cupos: </strong>
        {props.user.cupos}
      </Typography>
      
    </CardContent>

  </Card>

    
  );
};

export default EditTag;
