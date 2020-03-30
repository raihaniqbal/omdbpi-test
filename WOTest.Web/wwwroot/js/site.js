'use strict';

const e = React.createElement;

class MovieAutocomplete extends React.Component {
    constructor(props) {
        super(props);
        
        this.state = {
            movieSuggestions: []
        };
    }

    onTextChanged = (e) => {
        const searchText = e.target.value;
        var reactContext = this;

        if (searchText.length === 0)
            this.setState({ movieSuggestions: [] });
        else {
            
            $.ajax({
                url: '/Home/QuickSearch?searchText=' + searchText,
                dataType: 'json',
                success: function (response) {
                    console.log(response);
                    if (response.totalResults > 0)
                        reactContext.setState({ movieSuggestions: response.searchResults });
                }
            });
        }
    }

    renderSuggestions() {
        
        const { movieSuggestions } = this.state;

        if (movieSuggestions === undefined || movieSuggestions.length === 0)
            return null;
        else {
            return e('div', { className: 'suggestions' }, movieSuggestions.map((item) => e('li', { key: item.imdbId }, e('a', { href: '/Home/MovieDetails/?imdbId=' + item.imdbId }, item.title))));
        }
    }

    render() {

        const searchTextBox = e('input', { type: 'text', className: 'form-control', onChange: this.onTextChanged });

        return e('div', { className: 'autocomplete-container' }, searchTextBox, this.renderSuggestions());
    }
}


document.querySelectorAll('.movie-autocomplete')
    .forEach(domContainer => {
        ReactDOM.render(
            e(MovieAutocomplete),
            domContainer
        );
    });