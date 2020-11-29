

class OrderForm extends React.Component {        
    state = { citySender: '', addressSender: '', cityRecipient: '', addressRecipient: '', weight: '', dateTaken: Date };
    handleCitySender = e => {
        this.setState({ citySender: e.target.value })
    };
    handleAddressSender = e => {
        this.setState({ addressSender: e.target.value })
    };
    handleCityRecipient = e => {
        this.setState({ cityRecipient: e.target.value })
    };
    handleAddressRecipient = e => {
        this.setState({ addressRecipient: e.target.value })
    };
    handleWeight = e => {
        this.setState({ weight: e.target.value })
    };
    handleDateTaken = e => {
        this.setState({ dateTaken: e.target.value })
    };                    
	handleSubmit = e => {
		e.preventDefault();
		var citySender = this.state.citySender.trim();
		var addressSender = this.state.addressSender.trim();
		var cityRecipient = this.state.cityRecipient.trim();
		var addressRecipient = this.state.addressRecipient.trim();
		var weight = this.state.weight.trim();
		var dateTaken = this.state.dateTaken.trim();
		
		this.props.onOrderSubmit({
			citySender: citySender, addressSender: addressSender, addressSender: addressSender,
			cityRecipient: cityRecipient, addressRecipient: addressRecipient, weight: weight, dateTaken: dateTaken 
		});
		this.setState({ citySender: '', addressSender: '', cityRecipient: '', addressRecipient: '', weight: '', dateTaken: ''});
	};
	render() {
		return (
			<form  className="orderForm" onSubmit={this.handleSubmit} >				
				<div class="form-group">
					<label>Город отправителя</label>					
					<input class="form-control"  type="text" value={this.state.citySender} onChange={this.handleCitySender} autofocus required/>
				</div>
				<div class="form-group">
					<label>Адрес отправителя</label>
					<input class="form-control" type="text" value={this.state.addressSender} onChange={this.handleAddressSender} autofocus required />
				</div>
				<div class="form-group">
					<label>Город получателя</label>
					<input class="form-control" type="text" value={this.state.cityRecipient} onChange={this.handleCityRecipient} autofocus required />
				</div>
				<div class="form-group">
					<label>Адрес получателя</label>
					<input class="form-control" type="text" value={this.state.addressRecipient} onChange={this.handleAddressRecipient} autofocus required />
				</div>
				<div class="form-group">
					<label>Вес груза</label>
					<input class="form-control" type="text" value={this.state.weight} onChange={this.handleWeight} autofocus required />
				</div>
				<div class="form-group">
					<label>Дата забора груза</label>
					<input class="form-control" type="datetime-local"  onChange={this.handleDateTaken} autofocus required />
				</div>
				<input class="btn btn-primary" type="submit" value="Сохранить" />					
			</form>
		);
	}
}

class OrderSubmit extends React.Component {
	state = { data: this.props.initialData };
	handleOrderSubmit = order => {
		var data = new FormData();
		data.append('citySender', order.citySender);
		data.append('addressSender', order.addressSender);
		data.append('cityRecipient', order.cityRecipient);
		data.append('addressRecipient', order.addressRecipient);
		data.append('weight', order.weight);
		data.append('dateTaken', order.dateTaken);
		var xhr = new XMLHttpRequest();
		xhr.open('post', '/api/order', true);		
		xhr.send(data);		
	};
	render() {
		return (
			<div className="orderBox">				
				<OrderForm onOrderSubmit={this.handleOrderSubmit} />
				<a class="btn btn-primary" href="/" role="button">Вернуться к таблице</a>				
			</div>
		);
	}
}

ReactDOM.render(
	<OrderSubmit url="api/order" pollInterval={2000} />,
    document.getElementById('content')
);