import { Header } from "antd/es/layout/layout"
import Title from "antd/es/typography/Title"


const HeaderFragment: React.FC = () => {
	
	return (
		<Header style={{ display: 'flex', alignItems: 'center' }}>
			<Title level={1} style={{ fontFamily: "Nunito, serif", color: "White" }}> Poomsae </Title>
		</Header>
	)
}

export default HeaderFragment