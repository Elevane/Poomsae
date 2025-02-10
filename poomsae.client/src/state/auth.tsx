import { atom } from 'recoil'
import { AppUser } from '../Models/AppModels'


const authState = atom<AppUser>({
    key: 'auth',
    default: { "isAuthenticated": false, "username": undefined, "token": undefined }
})

export { authState }