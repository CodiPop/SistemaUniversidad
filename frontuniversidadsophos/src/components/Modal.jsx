import React, { useState, useEffect } from "react";
import {
  Button,
  Card,
  CardContent,
  Typography,
  Box,
  Modal as Modals,
} from "@mui/material";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 600,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};

const Modal = (props) => {
  
  /* const getData = async () => {
        try {
          const response = await axios.get("https://localhost:44351/api/cursos/InfoCursos/" + idCurso);
          console.log(response.data.query[0].nombreDocente);
          setCursosInfo(response);
          
        } catch (error) {
          console.log(error);
        }
      }; */
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => {
    setOpen(true);

    console.log(props.info)
    //console.log(props.info.query[0].nombreDocente)
    //var xd = props.info
    //console.log(" xd = ",xd.query[0])
    //getData();
  };
  const handleClose = () => setOpen(false);
  return (
    <div>
      <Button onClick={handleOpen}>Mas informacion</Button>
      <Modals
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Typography id="modal-modal-title" variant="h6" component="h2">
          Docente de la asignatura:
          </Typography>
          {/* <Typography component="h2">{props.info.nombreProfesor[0].nombreDocente}</Typography> */}
          <Typography id="modal-modal-title" variant="h6" component="h2">Cantidad de estudiantes matericulados:</Typography>
          {/* <Typography component="h2">{props.info.acumulado.inscritos}</Typography> */}
            
          <Typography id="modal-modal-description" sx={{ mt: 2 }}>
              
          </Typography>
        </Box>
      </Modals>
    </div>
  );
};

export default Modal;
