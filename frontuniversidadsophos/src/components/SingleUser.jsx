import React, { useEffect } from "react";
import { useGetMore } from "../hooks/useGetMore";
import { Button, Card, CardContent, Typography } from "@mui/material";
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
var isC= true;
export const SingleUser = ({
  nombreCurso,
  idCursoPrerrequisito,
  numCreditos,
  cupos,
  idCurso,
  idCursoPrerrequisitoNavigation,
}) => {
  const classes = useStyle();
  const handleClick = async () => {
    var response;
    try {
      response = await axios.get(
        "https://localhost:44351/api/cursosdocentes/BuscarIDcs/" + idCurso
      );

      await axios.delete(
        "https://localhost:44351/api/InscripcionesCursoes/deleteCD/" +
          response.data.idCursoDocente
      );
      
    } catch (error) {}
    try {
      await axios.delete(
        "https://localhost:44351/api/cursosdocentes/delete/" + idCurso
      );
    } catch (error) {}

    try {
      await axios.delete("https://localhost:44351/api/cursos/" + idCurso);
      window.location.reload(false);
    } catch (error) {}
  };

  const { data, addData } = useGetMore();

  const getData = async () => {
    const response = await axios.get(
      "https://localhost:44351/api/cursos/InfoCursos/" + idCurso
    );
    const { data } = response;
    const formateo= {... data.acumulado,... data.nombreProfesor}
    addData(formateo);
    
  };

  useEffect(() => {
    getData();
  }, []);

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
        <Modal info={data} getData isC></Modal>
      </CardContent>
    </Card>
  );
};

export default SingleUser;
