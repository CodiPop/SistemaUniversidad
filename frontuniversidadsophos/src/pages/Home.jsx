import { Box, Typography } from '@mui/material'
import { Container} from '@mui/system'
import React from 'react'
import Title from '../components/Title'
import { makeStyles } from '@material-ui/core/styles'
import List from '../components/List'
import SingleUser from '../components/SingleUser'

const data = {
    name: "Santiago",
    pais: "Colombia",
    correo: "sguerreroa@uninorte.edu.co"
  }

  const useStyles = makeStyles({
    container:{
        display:"flex",
        flexDirection:"column",
        justifyContent: "space-evenly",
        margin:"24px 8 px",
        height:"100%"

        
    }
  })

const Home = () => {
    const classes = useStyles();
  return (
    <React.Fragment>
    
    <Box className={classes.container}>

    <Container maxWidth="md" className={classes.container}>
    <Title text="Sistema de datos de la Universidad Sophos"/>
    <List/>
    </Container>

    </Box>

    </React.Fragment>

  )
}

export default Home