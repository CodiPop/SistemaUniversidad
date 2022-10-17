import React, {useEffect, useState} from 'react'
import axios from 'axios'
import SingleUser from './SingleUser';
import { Box } from '@mui/material';
import "./Styles/List.css"
const List = () => {
    const [cursos,setCursos] = useState([]);
    const getData = async () => {
        

        try {
            const response = await axios.get("https://localhost:44351/api/cursos")
            console.log(response.data);
            const { results } = response.data;
            console.log(results);
            setCursos(response.data);
            console.log(cursos);
            
        } catch (error) {
            console.log(error);
        }
    }

        useEffect (() => {
            getData()
        },[])

  return (
      <div >
        <div className='center'><h3>Cursos</h3></div>
        <Box>
        
        {cursos.map((item,index) => (
        <SingleUser key={index} {...item} isEdit/>
      ))}
        </Box>



      </div>
  );
};

export default List