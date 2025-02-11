import { useLocation, Navigate } from "react-router-dom";
import React from "react";
import { useRecoilState } from "recoil";
import { authState } from "../../state/auth";
import { AppUser } from "../../Models/AppModels";
import useLocalStorage from "../../Hooks/useLocalStorage";
import toast from "react-hot-toast";

interface RequireAuthProps {
    children: React.ReactNode;
}

const RequireAuth: React.FC<RequireAuthProps> = ({ children }) => {
    const [user, setUser] = useRecoilState<AppUser>(authState);
    const local = useLocalStorage();
    const location = useLocation();
    const localUser = local.GetUser();
    const isLocal = !user.isAuthenticated && localUser.isAuthenticated;
    if (isLocal && !user.isAuthenticated) {
        setUser(localUser)
    }

    if (!isLocal && !user.isAuthenticated) {
        toast.error("You must be connected to access this page");
        return <Navigate to="/login" state={{ from: location }} replace />;
    }

    return <>{children}</>;
};

export default RequireAuth;