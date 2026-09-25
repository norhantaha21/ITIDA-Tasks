import { useContext } from "react";
import { UserContext } from "../context/UserContext";
import ProfileActions from "./ProfileActions";

interface ProfileCardProps {
  onEdit: () => void;
  onLogout: () => void;
}

function ProfileCard({ onEdit, onLogout }: ProfileCardProps) {
  const context = useContext(UserContext);

  if (!context) return null;

  const { user } = context;

  if (!user) {
    return <p>No user logged in</p>;
  }

  return (
    <div>
      <h2>Profile</h2>

      <p>
        <strong>Name:</strong> {user.fullName}
      </p>

      <p>
        <strong>Email:</strong> {user.email}
      </p>

      <p>
        <strong>Age:</strong> {user.age}
      </p>

      <ProfileActions onEdit={onEdit} onLogout={onLogout} />
    </div>
  );
}

export default ProfileCard;
