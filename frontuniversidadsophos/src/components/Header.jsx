import React from "react";
import {
  AppBar,
  Toolbar,
  IconButton,
  Container,
  Link,
} from "@mui/material";
import { makeStyles } from "@material-ui/core/styles";
import{Link as RLink} from "react-router-dom";

const useStyle = makeStyles({
  menu: {
    display: "flex",
    justifyContent: "space-evenly",
    
  },
  topbar:{
    backgroundColor: "black"
  }
});
const Header = () => {
  const classes = useStyle();
  return (
    <AppBar  position="sticky" >
      <Container maxWidth="lg" >
        <Toolbar className={classes.menu}>
          <IconButton edge="start">
            <img src="logo512.png" alt="Logo" height="30px" />
          </IconButton>
          
          <Link component={RLink} to="/" color="inherit">
            Inicio
          </Link>
         
          <Link component={RLink} to="/Search" color="inherit">
            Buscar
          </Link>
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export default Header;
