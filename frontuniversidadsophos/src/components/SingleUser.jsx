import React,{useState, useEffect}from "react";
import {
  Button,
  Card,
  CardContent,
  Typography,
  Box,
} from "@mui/material";
import { Link as RLink } from "react-router-dom";
import { makeStyles } from "@material-ui/core/styles";
import axios from "axios";
import Modal from "./Modal";

const useStyle = makeStyles({
  cardUser: {
    width: "80%",
    margin: "8px auto",
  },

  cardMedia: {},
  carContent: {},
  actions: {},
});

export const SingleUser = ({
  nombreCurso,
  idCursoPrerrequisito,
  numCreditos,
  cupos,
  idCurso,
  idCursoPrerrequisitoNavigation,
}) => {
  const [cursosInfo,setCursosInfo] = useState([]);
  
  const classes = useStyle();
  const handleClick = async () => {
    try {
      await axios.delete("https://localhost:44351/api/cursos/" + idCurso);
      window.location.reload(false);
    } catch (error) {
      console.log(error);
    }
  };
  const getData = async () => {
    try {
      const response = await axios.get("https://localhost:44351/api/cursos/InfoCursos/" + idCurso);
      console.log(idCurso)
      console.log(response.data.query);
      setCursosInfo(response.data.query);
      
    } catch (error) {
      console.log(error);
    }
  }
  
  useEffect (() => {
    getData()
},[])
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
        <Button component={RLink} to="/Edit" state={{ id: idCurso }}>
          Editar
        </Button>
        <Button color="error" onClick={handleClick}>
          Eliminar
        </Button>
        {/* <Modal info={cursosInfo} ></Modal> */}
      </CardContent>
    </Card>
  );
};

export default SingleUser;
