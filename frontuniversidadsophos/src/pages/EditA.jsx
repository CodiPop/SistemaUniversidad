import Title from "../components/Title";
import UserFormA from "../components/UserFormA";
import React, { useState, useEffect } from "react";
import axios from "axios";
import EditTagA from "../components/EditTagA";
import { useLocation } from 'react-router-dom'
const EditA = () => {

  const location = useLocation();
  const proof = location.state
  console.log(proof)
  const id = proof.id;
  const intialState = {
    nombreAlumno: "",
    facultad: "",
    numDocumento:"",
    fechaNacimiento: ""


  };

  //const { id } = useParams();
  const [user, setUser] = useState(intialState);

  const getData = async () => {
    try {
      const response = await axios.get("https://localhost:44351/api/alumnos/"+id );
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
      <Title text="Edita el Alumno" />
      <EditTagA user={user} />
      <br></br>
      <UserFormA onChange={handleChange} user={user} isEdit />
    </div>
  );
};

export default EditA;
