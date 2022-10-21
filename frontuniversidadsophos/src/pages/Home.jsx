import { Box} from '@mui/material'
import React from 'react'
import Title from '../components/Title'
import { makeStyles } from '@material-ui/core/styles'
import List from '../components/List'



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


    <Title text="Sistema de datos de la Universidad Sophos"/>
    <List/>
    

    </Box>

    </React.Fragment>

  )
}

export default Home