import { Layout, Typography } from "antd"
import H1 from "../Atoms/Text/H1"
import { Link, useParams } from "react-router-dom"
import { useEffect, useState } from "react"
import { LoadingOutlined } from "@ant-design/icons"
import useUserService from "../../Hooks/Services/UseUserService"
import Logo from "../Atoms/Logo"
import AppLayout from "../Fragments/Generic/AppLayout"

const ConfirmPassword = () => {
    const { token } = useParams()
    const authService = useUserService()
    const [confirmation, setConfirmation] = useState<boolean>()
    const [loading, setLoading] = useState<boolean>(true)
    const [confirmationErrors, setConfirmationErrors] = useState<string>()

    const ConfirmPasswordStyle: React.CSSProperties = {
        maxHeight: 400,
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
    }

    useEffect(() => {
        const confirm = async () => {
            if (token === null || token === undefined) return setConfirmation(false)
            const res = await authService.confirmAccount(token)
            setLoading(false)
            if (res.failure) {
                setConfirmation(false)
                if (res.errors != null && res.errors["credentials"] != null) return setConfirmationErrors(res.errors["credentials"])
            }
            else {
                setConfirmation(true)
            }
        }
        confirm()
    }, [])

    return (
        <AppLayout>
            <Layout style={ConfirmPasswordStyle}>
                <Logo src="logo.svg" name="logo_connexion_poomsae" size="big" />
                <H1 >{"Confirm Password"}</H1>
                {loading && <LoadingOutlined />}
                {
                    confirmation ? (<Typography.Text type="success" >Your account was confirmed</Typography.Text>) : (confirmationErrors && <Typography.Text type="danger" >{confirmationErrors}</Typography.Text>)
                }
                <Link to="/" >Return</Link>
            </Layout>
        </AppLayout>
    )
}

export default ConfirmPassword