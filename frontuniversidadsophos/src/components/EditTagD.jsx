import React from "react";
import {
  Card,
  CardContent,
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

export const EditTagD = ( props) => {
  console.log(props.user)
  const classes = useStyle();

  return (
    <Card className={classes.cardUser}>
    <CardContent className={classes.carContent}>
      <Typography variant="body1">
        <strong>Nombre: </strong>
        {props.user.nombreDocente}
      </Typography>
      <Typography variant="body1">
        <strong>Titulo Acedemico: </strong>
        {props.user.nombreNivelAcademico}
      </Typography>
      <Typography variant="body1">
        <strong>Numero de documento: </strong>
        {props.user.numDocumento}
      </Typography>
      <Typography variant="body1">
        <strong>Fecha de Nacimiento: </strong>
        {props.user.fechaNacimiento}
      </Typography>
      
    </CardContent>

  </Card>

    
  );
};

export default EditTagD;
