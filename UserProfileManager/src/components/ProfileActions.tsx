import { memo } from "react";

interface ProfileActionsProps {
  onEdit: () => void;
  onLogout: () => void;
}

function ProfileActions({ onEdit, onLogout }: ProfileActionsProps) {
  return (
    <div>
      <button onClick={onEdit}>Edit</button>

      <button onClick={onLogout}>Logout</button>
    </div>
  );
}

export default memo(ProfileActions);
