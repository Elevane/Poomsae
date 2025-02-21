import { Layout, Typography } from "antd"
import H1 from "../Atoms/Text/H1"
import { Link, useParams } from "react-router-dom"
import { LoadingOutlined } from "@ant-design/icons"
import useUserService from "../../Hooks/Services/UseUserService"
import Logo from "../Atoms/Logo"
import AppLayout from "../Fragments/Generic/AppLayout"
import { useQuery } from "@tanstack/react-query"

const ConfirmPassword = () => {
    const { token } = useParams()
    const authService = useUserService()


    const ConfirmPasswordStyle: React.CSSProperties = {
        maxHeight: 400,
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
    }

    const { isPending, errors, data } = useQuery({
        queryKey: ["confirmPassword"],
        queryFn: () => authService.confirmAccount(token!)
    })

    return (
        <AppLayout>
            <Layout style={ConfirmPasswordStyle}>
                <Logo src="logo.svg" name="logo_connexion_poomsae" size="big" />
                <H1 >{"Confirm Password"}</H1>
                {isPending && <LoadingOutlined />}
                {errors && <Typography.Text type="danger" >{errors}</Typography.Text>}
                {data && (<Typography.Text type="success" >Your account was confirmed</Typography.Text>)}
                <Link to="/" >Return</Link>
            </Layout>
        </AppLayout>
    )
}

export default ConfirmPassword