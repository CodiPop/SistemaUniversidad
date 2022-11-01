import React, { useEffect } from "react";
import {
  Button,
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

  const [open, setOpen] = React.useState(false);
  const handleOpen = () => {
    setOpen(true);
  };


  const handleClose = () => {

    
    setOpen(false);
  }
  
useEffect (() => {

  
},[open])
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

          {props.isC?<Typography id="modal-modal-title" variant="h6" component="h2">Docente de la asignatura:</Typography>:<Typography id="modal-modal-title" variant="h6" component="h2">Cursos Matriculados:</Typography>}
          {props.isC?<Typography component="h2">{props.info[0]?.nombreDocente}</Typography>:<Typography component="h2">
            {/* { Array(props.info.cursos).length>0 && Array(props.info.cursos).map((x)=>{
            <Typography>
              {x?.nombreCurso}
              {console.log(props.info,'nombre curso es')}
            </Typography>

          })    } */}{/* {Array(props.info2).map((x,i)=><p key={i}>{x?.nombreCurso}</p>)} */}{console.log(props.info2)}</Typography>}
          {props.isC?<Typography id="modal-modal-title" variant="h6" component="h2">Cantidad de estudiantes matriculados:</Typography>:<Typography id="modal-modal-title" variant="h6" component="h2">Numero Total de Creditos Matriculados:</Typography>}
          {props.isC?<Typography component="h2">{props.info.inscritos}</Typography>:<Typography component="h2">{props.info}</Typography>}
          
          
          <Typography id="modal-modal-description" sx={{ mt: 2 }}>
          
          </Typography>
        </Box>
      </Modals>
    </div>
  );
};

export default Modal;
