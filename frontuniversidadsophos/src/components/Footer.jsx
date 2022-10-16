import React from "react";
import { Container, Typography, Grid, Link } from "@mui/material";
import { makeStyles } from "@material-ui/core/styles";

const useStyles = makeStyles((theme) => ({
  foorter: {
    width: "100%",
    padding: "24px 0",
    color: "white",
    background: theme.palette.primary.main,
  },
}));

const Footer = () => {
  const classes = useStyles();
  return (
    <footer className={classes.foorter}>
      <Container maxWidth="md">
        <Grid container align="center">
          <Grid item xs={12} sm={4}>
            <Typography variant="h5">
              <strong>Politicas del sitio</strong>
            </Typography>
            <Link href="#" color="inherit">
              <Typography>Politicas y privacidad</Typography>
            </Link>
            <Link href="#" color="inherit">
              <Typography>Terminos y Condiciones</Typography>
            </Link>
          </Grid>
          <Grid item xs={12} sm={4}>
            <Typography variant="h5">
              <strong>Servicios</strong>
            </Typography>
            <Link href="#" color="inherit">
              <Typography>Lavado de autos</Typography>
            </Link>
          </Grid>

          <Grid item xs={12} sm={4}>
            <Typography variant="h5">
              <strong>Contactanos</strong>
            </Typography>
            <Link href="#" color="inherit">
              <Typography>4302841</Typography>
            </Link>
          </Grid>
        </Grid>
      </Container>
    </footer>
  );
};

export default Footer;
