import { useLocation } from "react-router-dom";
import { Navigate } from "react-router-dom";
import { useResetRecoilState } from "recoil";
import { authState } from "../../state/auth";
import useLocalStorage from "../../Hooks/useLocalStorage";

export default function Logout() {
    const location = useLocation();
    const localStorage = useLocalStorage();
    const resetList = useResetRecoilState(authState);
    localStorage.removeUser();
    resetList();
    return <Navigate to="/login" state={{ from: location }} replace />;
}