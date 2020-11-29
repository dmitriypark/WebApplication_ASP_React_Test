class Order extends React.Component {

    render() {
        return (
            <tr className="order">
                <td className="orderId">{this.props.orderId}</td>
                <td className="citySender">{this.props.citySender}</td>
                <td className="addressSender">{this.props.addressSender}</td>
                <td className="cityRecipient">{this.props.cityRecipient}</td>
                <td className="addressRecipient">{this.props.addressRecipient}</td>
                <td className="weight">{this.props.weight}</td>
                <td className="dateTaken">{this.props.dateTaken}</td>
            </tr>
        );
    }
}

class OrderList extends React.Component {
    render() {
        const orderNodes = this.props.data.map(order => (
            <Order orderId={order.orderId} citySender={order.citySender} addressSender={order.addressSender} cityRecipient={order.cityRecipient}
                addressRecipient={order.addressRecipient} weight={order.weight} dateTaken={order.dateTaken}>
            </Order>
        ));
        return <table className="orderNodes" class="table table-bordered table-striped">
            <tr>
                <th>номер заказа</th>
                <th>Город отправителя</th>
                <th>Адрес отправителя</th>
                <th>Город получателя</th>
                <th>Адрес получателя</th>
                <th>Вес груза</th>
                <th>Дата забора груза</th>
            </tr>
            {orderNodes}
        </table>
    }
}

class OrderBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
    }
    loadFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }
    componentDidMount() {
        this.loadFromServer();
        window.setInterval(
            () => this.loadFromServer(),
            this.props.pollInterval,
        );
    }
    render() {
        return (
            <div className="OrderBox" >
                <a class="btn btn-primary" href="/Order/Form" role="button">Добавление заказов</a>
                <OrderList data={this.state.data} />
                <a class="btn btn-primary" href="/Order/Form" role="button">Добавление заказов</a>
            </div>
        );
    }
}

ReactDOM.render(
    <OrderBox url="api/order" pollInterval={2000} />,
    document.getElementById('content')
);


