import SingleUser from "../components/SingleUser";
import Title from "../components/Title";
import UserForm from "../components/UserForm";
import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
const Edit = () => {
  const intialState = {
    name: "",
    pais: "",
    correo: "",
  };

  const { id } = useParams();
  const [user, setUser] = useState(intialState);

  const getData = async () => {
    try {
      const response = await axios.get("http://localhost:3000/users/" + id);
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
      <Title text="Edita un usuario" />
      <SingleUser user={user} />
      <br></br>
      <UserForm onChange={handleChange} user={user} isEdit />
    </div>
  );
};

export default Edit;
