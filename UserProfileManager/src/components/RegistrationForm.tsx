import { useContext, useEffect, useRef, useState } from "react";
import { UserContext } from "../context/UserContext";
import type { User } from "../Types/User";

interface RegistrationFormProps {
  onSuccess: () => void;
}

function RegistrationForm({ onSuccess }: RegistrationFormProps) {
  const context = useContext(UserContext);

  const nameInputRef = useRef<HTMLInputElement>(null);

  const [formData, setFormData] = useState({
    fullName: "",
    email: "",
    password: "",
    confirmPassword: "",
    age: "",
  });

  const [errors, setErrors] = useState({
    fullName: "",
    email: "",
    password: "",
    confirmPassword: "",
    age: "",
  });

  useEffect(() => {
    nameInputRef.current?.focus();
  }, []);

  if (!context) return null;

  const { setUser } = context;

  function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
    const { name, value } = e.target;

    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  function validate() {
    const newErrors = {
      fullName: "",
      email: "",
      password: "",
      confirmPassword: "",
      age: "",
    };

    if (!formData.fullName.trim()) {
      newErrors.fullName = "Full name is required";
    } else if (formData.fullName.trim().length < 3) {
      newErrors.fullName = "Full name must be at least 3 characters";
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!formData.email) {
      newErrors.email = "Email is required";
    } else if (!emailRegex.test(formData.email)) {
      newErrors.email = "Invalid email format";
    }

    if (!formData.password) {
      newErrors.password = "Password is required";
    } else if (formData.password.length < 8) {
      newErrors.password = "Password must be at least 8 characters";
    }

    if (!formData.confirmPassword) {
      newErrors.confirmPassword = "Confirm password is required";
    } else if (formData.confirmPassword !== formData.password) {
      newErrors.confirmPassword = "Passwords do not match";
    }

    if (!formData.age) {
      newErrors.age = "Age is required";
    } else if (Number(formData.age) < 18) {
      newErrors.age = "Age must be at least 18";
    }

    return newErrors;
  }

  function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    const validationErrors = validate();

    setErrors(validationErrors);

    const hasErrors = Object.values(validationErrors).some(
      (error) => error !== "",
    );

    if (hasErrors) {
      return;
    }

    const user: User = {
      fullName: formData.fullName,
      email: formData.email,
      password: formData.password,
      age: Number(formData.age),
    };

    localStorage.setItem("user", JSON.stringify(user));

    setUser(user);

    onSuccess();
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>Register</h2>

      <div>
        <label>Full Name</label>

        <input
          ref={nameInputRef}
          type="text"
          name="fullName"
          value={formData.fullName}
          onChange={handleChange}
        />

        {errors.fullName && <p>{errors.fullName}</p>}
      </div>

      <div>
        <label>Email</label>

        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
        />

        {errors.email && <p>{errors.email}</p>}
      </div>

      <div>
        <label>Password</label>

        <input
          type="password"
          name="password"
          value={formData.password}
          onChange={handleChange}
        />

        {errors.password && <p>{errors.password}</p>}
      </div>

      <div>
        <label>Confirm Password</label>

        <input
          type="password"
          name="confirmPassword"
          value={formData.confirmPassword}
          onChange={handleChange}
        />

        {errors.confirmPassword && <p>{errors.confirmPassword}</p>}
      </div>

      <div>
        <label>Age</label>

        <input
          type="number"
          name="age"
          value={formData.age}
          onChange={handleChange}
        />

        {errors.age && <p>{errors.age}</p>}
      </div>

      <button type="button" onClick={() => nameInputRef.current?.focus()}>
        Focus Name
      </button>

      <button type="submit">Register</button>
    </form>
  );
}

export default RegistrationForm;
