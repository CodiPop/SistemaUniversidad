import React,{useRef,useState,useEffect} from 'react'
import { makeStyles } from "@material-ui/core/styles";
import { TextField,FormControlLabel,Radio,FormControl,FormLabel,RadioGroup, FormHelperText,Box,Grid} from '@mui/material'
import axios from "axios"
import SingleUser from '../components/SingleUser';
import SingleUserA from '../components/SingleUserA';
import SingleUserD from '../components/SingleUserD';
/* const handleChangeSearch = () =>{
  console.log()
} */

var nBool = false;
var fBool = false;
const handleChangeN = () =>{
  fBool = false;
  nBool= true;
  console.log("nBoll "+nBool, fBool)
}
const handleChangeF = () =>{
  nBool= false;
  fBool= true;
  console.log("fBoll "+fBool, nBool)
}
const handleChange = () =>{
  nBool= true;
  fBool = true;
  console.log(nBool, fBool)
}
const useStyles = makeStyles({
  container: {

    width: "50%",
    margin: "8px auto",

  }})
var nombre;
const Search = () => {


  const textRef = useRef();
  const showRefContent = () => {
    nombre = textRef.current.value;
    console.log(textRef.current.value);
    getData();
  };
  const classes = useStyles();
  const [cursos,setCursos] = useState([]);
  const [alumnos,setAlumnos] = useState([]);
  const [alumnosF,setAlumnosF] = useState([]);
  const [docentes,setDocentes] = useState([]);

  const getData = async () => {

        

    try {
        
        const responseC = await axios.get("https://localhost:44351/api/cursos/Buscar/"+nombre)
        const responseA = await axios.get("https://localhost:44351/api/alumnos/Buscar/"+nombre)
        const responseAF = await axios.get("https://localhost:44351/api/alumnos/BuscarF/"+nombre)
        const responseD = await axios.get("https://localhost:44351/api/docentes/Buscar/"+nombre)
        console.log(responseC.data);
        console.log(responseA.data);
        console.log(responseAF.data);
        console.log(responseD.data);
        setCursos(responseC.data);
        setAlumnos(responseA.data);
        setAlumnosF(responseAF.data);
        setDocentes(responseD.data);
       
    } catch (error) {
        console.log(error);
    }
}


  return (
    <div>
      <br></br>
      <div className={classes.container}>
      <TextField fullWidth 
      id="outlined-search" 
      label="Digite aqui lo que quiere buscar" 
      type="search" /* onChange={showRefContent} */ 
      inputRef={textRef}
      onKeyDown={(e) => {if (e.key === "Enter") {
        showRefContent();
      }}}
      />
      <FormHelperText>Presione Enter</FormHelperText>



      
{/*       <FormControl>
      <RadioGroup row>
        
        <FormControlLabel value="nombre" control={<Radio />} label="Nombre" onChange={handleChangeN}/>
        <FormControlLabel value="facultad" control={<Radio />} label="Facultad" onChange={handleChangeF}/>
        <FormControlLabel value="ambos" control={<Radio />} label="Ambos" onChange={handleChange}/>
      </RadioGroup>
    </FormControl> */}
      </div>
      <Box sx={{ flexGrow: 1 }}>
      <Grid container spacing={3}>
        <Grid item xs={4}>

        <div className='center'><h3>Cursos</h3></div>
        <Box >
        <Box textAlign='center'>
        
        </Box>
        {cursos.map((item,index) => (
        <SingleUser key={index} {...item} isEdit />
        ))}
        </Box>
        </Grid>
        <Grid item xs={4}>
        <div className='center'><h3>Alumnos</h3></div>
        <Box>
        <Box textAlign='center'>
        
        </Box>
        {alumnos.map((item,index) => (
        <SingleUserA key={index} {...item} isEdit/>
        ))}
        </Box>
        </Grid>
        <Grid item xs={4}>
        <div className='center'><h3>Profesores</h3></div>
        <Box>
        <Box textAlign='center'>
        
        </Box>

        {docentes.map((item,index) => (
            
        <SingleUserD key={index} {...item} cadenaA isEdit/>
        ))}
        </Box> 
        </Grid>
        <Grid item xs={4}>
        <div className='center'><h3>Facultad</h3></div>
        <Box>
        <Box textAlign='center'>
        
        </Box>

        {alumnosF.map((item,index) => (
            
        <SingleUserA key={index} {...item} cadenaA isEdit/>
        ))}
        </Box> 
        </Grid>
      </Grid>
    </Box>

    </div>
  )
}

export default Search