import { useRecoilState } from "recoil"
import { useNavigate } from "react-router"
import toast from "react-hot-toast"
import { authState } from "../../state/auth"
import useLocalStorage from "../useLocalStorage"
import { AppUser } from "../../Models/AppModels"
import { LoginRequest, RegisterRequest } from "../../Models/apiModels"
import { ApiResult, LoginRegisterResponse } from "../../Models/ApiResult"
import api from "../Api/Api"
import ContentType from "../Api/ContentType"


const useUserService = () => {
  const [, setAuth] = useRecoilState(authState)
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
      navigate("/hub")
    }
    if (response.failure && response.errors)
      toast.error(response.errors["email"])
  }

  async function confirmAccount(token: string) {
    return await api.patch<string>(`${apiBaseRoute}/auth/confirm/${token}`, null, ContentType.json)
  }


  return { register, login, confirmAccount }
}
export default useUserService