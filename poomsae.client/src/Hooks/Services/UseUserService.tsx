import { useRecoilState } from "recoil"
import { useNavigate } from "react-router"
import toast from "react-hot-toast"
import { authState } from "../../state/auth"
import useLocalStorage from "../useLocalStorage"
import { AppUser } from "../../Models/AppModels"
import { DeleteRequest, LoginRequest, RegisterRequest, ResetPasswordRequest } from "../../Models/apiModels"
import { ApiResult, LoginRegisterResponse } from "../../Models/ApiResult"
import api from "../Api/Api"
import ContentType from "../Api/ContentType"

const useUserService = () => {
    const [auth, setAuth] = useRecoilState(authState)
    const local = useLocalStorage()
    const navigate = useNavigate()

    const apiBaseRoute = `${import.meta.env.VITE_APP_API_URL}/api`

    const saveUser = (user: AppUser) => {
        setAuth(user)
        local.SetUser(user)
    }

    async function login(content: LoginRequest) {
        const response: ApiResult<LoginRegisterResponse> = await api.post<LoginRegisterResponse>(`${apiBaseRoute}/auth/login`, content)
        if (!response.failure) {
            saveUser({ isAuthenticated: true, username: content.email, token: response.result?.token })
            navigate("/hub")
        }
        if (response.failure && response.errors)
            toast.error(response.errors["credentials"])
    }

    async function register(content: RegisterRequest) {
        const response: ApiResult<LoginRegisterResponse> = await api.post<LoginRegisterResponse>(`${apiBaseRoute}/auth/register`, content)
        if (!response.failure) {
            saveUser({ isAuthenticated: true, username: content.email, token: response.result?.token })
            toast.success("Your account was created successfully, check your emails to confirm your account")
        }
        if (response.failure && response.errors)
            toast.error(response.errors["email"])
    }

    async function deleteAccount(content: DeleteRequest) {
        const res = await api.del<string>(`${apiBaseRoute}/auth/delete`, content, ContentType.json, auth.token)
        if (!res.failure) navigate("/logout")
    }

    async function resetPassword(request: ResetPasswordRequest) {
        const res = await api.patch<string>(`${apiBaseRoute}/authSettings/resetPassword`, request, ContentType.json, auth.token)
        if (res.failure && res.errors != null)
            toast.error(res.errors["credentials"])
        else if (!res.failure) {
            toast.success("Password changed successfully")
        }
    }

    async function confirmAccount(token: string) {
        const res = await api.patch<string>(`${apiBaseRoute}/auth/confirm/${token}`, null, ContentType.json)
        if (res.failure && res.errors != null)
            throw new Error(res.errors["credentials"])
        return ""
    }

    return { register, login, confirmAccount, deleteAccount, resetPassword }
}
export default useUserService