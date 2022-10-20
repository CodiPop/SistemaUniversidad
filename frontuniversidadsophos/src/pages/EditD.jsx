import SingleUser from "../components/SingleUser";
import Title from "../components/Title";
import UserFormD from "../components/UserFormD";
import React, { useState, useEffect } from "react";
import axios from "axios";
import EditTagD from "../components/EditTagD";
import { useLocation } from 'react-router-dom'
const EditD = () => {

  const location = useLocation();
  const proof = location.state
  console.log(proof)
  const id = proof.id;
  const intialState = {
    nombreDocente: "",
    nombreNivelAcademico: "",
    numDocumento:"",
    fechaNacimiento: ""


  };

  //const { id } = useParams();
  const [user, setUser] = useState(intialState);

  const getData = async () => {
    try {
      const response = await axios.get("https://localhost:44351/api/docentes/"+id );
      const { data } = response;
      setUser(data);
      console.log(response);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    getData();
  }, []);

  const handleChange = (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  return (
    <div>
      <Title text="Edita al Docente" />
      <EditTagD user={user} />
      <br></br>
      <UserFormD onChange={handleChange} user={user} isEdit />
    </div>
  );
};

export default EditD;
