import React, { useState } from "react";
import axios from "axios";
import { useCookies } from "react-cookie";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import useCustomToast from "../../../utils/useToast";

interface LoginFormProps {
  handleCloseForm: () => void;
}

const LoginForm: React.FC<LoginFormProps> = ({ handleCloseForm }) => {
  const { showSuccessToast } = useCustomToast();
  const [errorMessage, setErrorMessage] = useState<string | null>(null);
  const [, setCookie] = useCookies(["isAuthenticated"]);

  const initialValues = {
    accessCode: "",
  };

  const validationSchema = Yup.object({
    accessCode: Yup.string().required("Access code is required"),
  });

  const handleSubmit = async (values: any) => {
    try {
      const validateResponse = await axios.post(
        "https://localhost:7266/api/validate",
        {
          accessCode: values.accessCode,
        }
      );

      if (validateResponse.status === 200) {
        const expirationDate = new Date();
        expirationDate.setHours(expirationDate.getHours() + 6);
        setCookie("isAuthenticated", "true", {
          path: "/",
          expires: expirationDate,
        });
        setCookie("isAuthenticated", "true", { path: "/" });
        handleCloseForm();
        showSuccessToast("Access granted");
        window.location.href = "/menu";
      } else {
        setErrorMessage("Invalid access code");
      }
    } catch (error) {
      setErrorMessage("Invalid access code");
    }
  };

  return (
    <Formik
      initialValues={initialValues}
      validationSchema={validationSchema}
      onSubmit={handleSubmit}
    >
      <Form className="bg-white px-6 py-8 rounded-md w-1/4 relative">
        <div
          className="absolute font-bold text-2xl top-2 right-5 cursor-pointer"
          onClick={handleCloseForm}
        >
          x
        </div>
        <div className="mb-5">
          <label
            className="text-red-500 font-bold text-2xl block mb-5"
            htmlFor="accessCode"
          >
            Access Code
          </label>
          <Field
            className=" rounded-md border border-gray-400 w-full p-2"
            type="text"
            id="accessCode"
            name="accessCode"
          />
          <ErrorMessage
            className="text-md text-red-500"
            name="accessCode"
            component="div"
          />
        </div>

        <button className="text-white red rounded-md w-full py-2" type="submit">
          Submit
        </button>
        {errorMessage && (
          <div className="text-md text-red-500 mt-2">* {errorMessage}</div>
        )}
      </Form>
    </Formik>
  );
};

export default LoginForm;
