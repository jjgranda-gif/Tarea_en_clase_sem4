using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

<? xml version = "1.0" encoding = "utf-8" ?>
< ContentPage xmlns = "http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns: x = "http://schemas.microsoft.com/winfx/2009/xaml"
             x: Class = "Tarea_en_clase_sem4.MainPage"
             Shell.NavBarIsVisible = "False"
             BackgroundColor = "#EEF2F9" >

    < !--ScrollView para poder desplazarse en pantallas pequeñas -->
    <ScrollView>

        <!-- Ancho máximo y centrado: se ve como celular incluso en Windows -->
        <VerticalStackLayout Padding="20" Spacing="18"
                             MaximumWidthRequest="520"
                             HorizontalOptions="Center">

            <!-- ENCABEZADO con degradado azul -->
            <Border StrokeThickness="0" Padding="24,28">
                <Border.StrokeShape>
                    <RoundRectangle CornerRadius="24" />
                </Border.StrokeShape>
                <Border.Background>
                    <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
                        <GradientStop Color="#173F82" Offset="0.0" />
                        <GradientStop Color="#3B7DDD" Offset="1.0" />
                    </LinearGradientBrush>
                </Border.Background>
                <Border.Shadow>
                    <Shadow Brush="#173F82" Opacity="0.35" Radius="16" Offset="0,6" />
                </Border.Shadow>
                <VerticalStackLayout Spacing="6">
                    <Label Text="INSTITUTO"
                           TextColor="#BFD4F5" FontSize="12"
                           FontAttributes="Bold" CharacterSpacing="3" />
                    <Label Text="Sudamericano"
                           TextColor="White" FontSize="30" FontAttributes="Bold" />
                    <Label Text="Sistema de calificaciones"
                           TextColor="#DCE8FA" FontSize="14" />
                </VerticalStackLayout>
            </Border>

            <!-- TARJETA: DATOS GENERALES -->
            <Border BackgroundColor="White" StrokeThickness="0" Padding="20">
                <Border.StrokeShape>
                    <RoundRectangle CornerRadius="20" />
                </Border.StrokeShape>
                <Border.Shadow>
                    <Shadow Brush="#1F4E9C" Opacity="0.12" Radius="12" Offset="0,4" />
                </Border.Shadow>
                <VerticalStackLayout Spacing="10">

                    <!-- Título de la tarjeta con insignia -->
                    <HorizontalStackLayout Spacing="12">
                        <Border BackgroundColor="#E8F0FE" StrokeThickness="0"
                                WidthRequest="34" HeightRequest="34">
                            <Border.StrokeShape>
                                <RoundRectangle CornerRadius="17" />
                            </Border.StrokeShape>
                            <Label Text="i" TextColor="#1F4E9C" FontSize="16"
                                   FontAttributes="Bold"
                                   HorizontalOptions="Center" VerticalOptions="Center" />
                        </Border>
                        <Label Text="Datos generales" FontSize="18"
                               FontAttributes="Bold" TextColor="#1B2A41"
                               VerticalOptions="Center" />
                    </HorizontalStackLayout>

                    <Label Text="Estudiante" TextColor="#5B6B82" FontSize="13" />
                    <!-- Los nombres se cargan desde MainPage.xaml.cs -->
                    <Border BackgroundColor="#F4F6FB" StrokeThickness="0" Padding="10,0">
                        <Border.StrokeShape>
                            <RoundRectangle CornerRadius="12" />
                        </Border.StrokeShape>
                        <Picker x:Name = "pickerEstudiante"
                                Title = "Seleccione un estudiante"
                                TextColor = "#1B2A41" TitleColor = "#8A97AB" />
                    </ Border >
                    < Label x: Name = "errEstudiante" TextColor = "#C62828"
                           FontSize = "12" IsVisible = "False" />

                    < Label Text = "Fecha" TextColor = "#5B6B82" FontSize = "13" />
                    < Border BackgroundColor = "#F4F6FB" StrokeThickness = "0" Padding = "10,0" >
                        < Border.StrokeShape >
                            < RoundRectangle CornerRadius = "12" />
                        </ Border.StrokeShape >
                        < DatePicker x: Name = "dateFecha" TextColor = "#1B2A41" />
                    </ Border >
                </ VerticalStackLayout >
            </ Border >

            < !--TARJETA: PARCIAL 1 -->
            <Border BackgroundColor="White" StrokeThickness="0" Padding="20">
                <Border.StrokeShape>
                    <RoundRectangle CornerRadius="20" />
                </Border.StrokeShape>
                <Border.Shadow>
                    <Shadow Brush="#1F4E9C" Opacity="0.12" Radius="12" Offset="0,4" />
                </Border.Shadow>
                <VerticalStackLayout Spacing="10">

                    <HorizontalStackLayout Spacing="12">
                        <Border BackgroundColor="#1F4E9C" StrokeThickness="0"
                                WidthRequest="34" HeightRequest="34">
                            <Border.StrokeShape>
                                <RoundRectangle CornerRadius="17" />
                            </Border.StrokeShape>
                            <Label Text="1" TextColor="White" FontSize="16"
                                   FontAttributes="Bold"
                                   HorizontalOptions="Center" VerticalOptions="Center" />
                        </Border>
                        <Label Text="Primer parcial" FontSize="18"
                               FontAttributes="Bold" TextColor="#1B2A41"
                               VerticalOptions="Center" />
                    </HorizontalStackLayout>

                    <!-- Seguimiento 1 con etiqueta de peso -->
                    <Grid ColumnDefinitions="*,Auto">
                        <Label Text="Nota Seguimiento 1 (sobre 10)" TextColor="#5B6B82"
                               FontSize="13" VerticalOptions="Center" />
                        <Border Grid.Column="1" BackgroundColor="#E8F0FE"
                                StrokeThickness="0" Padding="10,3">
                            <Border.StrokeShape>
                                <RoundRectangle CornerRadius="10" />
                            </Border.StrokeShape>
                            <Label Text="30%" TextColor="#1F4E9C"
                                   FontSize="11" FontAttributes="Bold" />
                        </Border>
                    </Grid>
                    <Border BackgroundColor="#F4F6FB" StrokeThickness="0" Padding="10,0">
                        <Border.StrokeShape>
                            <RoundRectangle CornerRadius="12" />
                        </Border.StrokeShape>
                        <Entry x:Name = "entSeg1" Placeholder = "0 a 10"
                               Keyboard = "Numeric" TextColor = "#1B2A41"
                               PlaceholderColor = "#A5B0C2" BackgroundColor = "Transparent" />
                    </ Border >
                    < Label x: Name = "errSeg1" TextColor = "#C62828"
                           FontSize = "12" IsVisible = "False" />

                    < !--Examen 1 con etiqueta de peso -->
                    <Grid ColumnDefinitions="*,Auto">
                        <Label Text="Examen 1 (sobre 10)" TextColor="#5B6B82"
                               FontSize="13" VerticalOptions="Center" />
                        <Border Grid.Column="1" BackgroundColor="#E8F0FE"
                                StrokeThickness="0" Padding="10,3">
                            <Border.StrokeShape>
                                <RoundRectangle CornerRadius="10" />
                            </Border.StrokeShape>
                            <Label Text="20%" TextColor="#1F4E9C"
                                   FontSize="11" FontAttributes="Bold" />
                        </Border>
                    </Grid>
                    <Border BackgroundColor="#F4F6FB" StrokeThickness="0" Padding="10,0">
                        <Border.StrokeShape>
                            <RoundRectangle CornerRadius="12" />
                        </Border.StrokeShape>
                        <Entry x:Name = "entExa1" Placeholder = "0 a 10"
                               Keyboard = "Numeric" TextColor = "#1B2A41"
                               PlaceholderColor = "#A5B0C2" BackgroundColor = "Transparent" />
                    </ Border >
                    < Label x: Name = "errExa1" TextColor = "#C62828"
                           FontSize = "12" IsVisible = "False" />
                </ VerticalStackLayout >
            </ Border >

            < !--TARJETA: PARCIAL 2 -->
            <Border BackgroundColor="White" StrokeThickness="0" Padding="20">
                <Border.StrokeShape>
                    <RoundRectangle CornerRadius="20" />
                </Border.StrokeShape>
                <Border.Shadow>
                    <Shadow Brush="#1F4E9C" Opacity="0.12" Radius="12" Offset="0,4" />
                </Border.Shadow>
                <VerticalStackLayout Spacing="10">

                    <HorizontalStackLayout Spacing="12">
                        <Border BackgroundColor="#3B7DDD" StrokeThickness="0"
                                WidthRequest="34" HeightRequest="34">
                            <Border.StrokeShape>
                                <RoundRectangle CornerRadius="17" />
                            </Border.StrokeShape>
                            <Label Text="2" TextColor="White" FontSize="16"
                                   FontAttributes="Bold"
                                   HorizontalOptions="Center" VerticalOptions="Center" />
                        </Border>
                        <Label Text="Segundo parcial" FontSize="18"
                               FontAttributes="Bold" TextColor="#1B2A41"
                               VerticalOptions="Center" />
                    </HorizontalStackLayout>

                    <!-- Seguimiento 2 con etiqueta de peso -->
                    <Grid ColumnDefinitions="*,Auto">
                        <Label Text="Nota Seguimiento 2 (sobre 10)" TextColor="#5B6B82"
                               FontSize="13" VerticalOptions="Center" />
                        <Border Grid.Column="1" BackgroundColor="#E8F0FE"
                                StrokeThickness="0" Padding="10,3">
                            <Border.StrokeShape>
                                <RoundRectangle CornerRadius="10" />
                            </Border.StrokeShape>
                            <Label Text="30%" TextColor="#1F4E9C"
                                   FontSize="11" FontAttributes="Bold" />
                        </Border>
                    </Grid>
                    <Border BackgroundColor="#F4F6FB" StrokeThickness="0" Padding="10,0">
                        <Border.StrokeShape>
                            <RoundRectangle CornerRadius="12" />
                        </Border.StrokeShape>
                        <Entry x:Name = "entSeg2" Placeholder = "0 a 10"
                               Keyboard = "Numeric" TextColor = "#1B2A41"
                               PlaceholderColor = "#A5B0C2" BackgroundColor = "Transparent" />
                    </ Border >
                    < Label x: Name = "errSeg2" TextColor = "#C62828"
                           FontSize = "12" IsVisible = "False" />

                    < !--Examen 2 con etiqueta de peso -->
                    <Grid ColumnDefinitions="*,Auto">
                        <Label Text="Examen 2 (sobre 10)" TextColor="#5B6B82"
                               FontSize="13" VerticalOptions="Center" />
                        <Border Grid.Column="1" BackgroundColor="#E8F0FE"
                                StrokeThickness="0" Padding="10,3">
                            <Border.StrokeShape>
                                <RoundRectangle CornerRadius="10" />
                            </Border.StrokeShape>
                            <Label Text="20%" TextColor="#1F4E9C"
                                   FontSize="11" FontAttributes="Bold" />
                        </Border>
                    </Grid>
                    <Border BackgroundColor="#F4F6FB" StrokeThickness="0" Padding="10,0">
                        <Border.StrokeShape>
                            <RoundRectangle CornerRadius="12" />
                        </Border.StrokeShape>
                        <Entry x:Name = "entExa2" Placeholder = "0 a 10"
                               Keyboard = "Numeric" TextColor = "#1B2A41"
                               PlaceholderColor = "#A5B0C2" BackgroundColor = "Transparent" />
                    </ Border >
                    < Label x: Name = "errExa2" TextColor = "#C62828"
                           FontSize = "12" IsVisible = "False" />
                </ VerticalStackLayout >
            </ Border >

            < !--BOTONES-- >
            < Button Text = "Calcular nota"
                    Clicked = "OnCalcularClicked"
                    BackgroundColor = "#1F4E9C" TextColor = "White"
                    FontSize = "16" FontAttributes = "Bold"
                    CornerRadius = "16" HeightRequest = "54" />

            < Button Text = "Limpiar"
                    Clicked = "OnLimpiarClicked"
                    BackgroundColor = "White" TextColor = "#1F4E9C"
                    BorderColor = "#C9D6EE" BorderWidth = "1"
                    FontSize = "15" FontAttributes = "Bold"
                    CornerRadius = "16" HeightRequest = "50" />

            < !--TARJETA DE RESULTADO(oculta hasta que se calcula) -->
            < Border x: Name = "cardResultado" IsVisible = "False"
                    BackgroundColor = "#E8F5E9" StrokeThickness = "0" Padding = "24" >
                < Border.StrokeShape >
                    < RoundRectangle CornerRadius = "20" />
                </ Border.StrokeShape >
                < VerticalStackLayout Spacing = "8" >
                    < Label Text = "RESULTADO" FontSize = "12" FontAttributes = "Bold"
                           CharacterSpacing = "3" TextColor = "#5B6B82"
                           HorizontalOptions = "Center" />
                    < Label x: Name = "lblEstado" FontSize = "28" FontAttributes = "Bold"
                           HorizontalOptions = "Center" />
                    < Label x: Name = "lblNotaFinal" FontSize = "18" FontAttributes = "Bold"
                           HorizontalOptions = "Center" TextColor = "#1B2A41" />
                    < Label x: Name = "lblDetalle" FontSize = "13"
                           HorizontalOptions = "Center" TextColor = "#5B6B82" />
                </ VerticalStackLayout >
            </ Border >

            < !--Espacio final para que el último elemento no quede pegado al borde -->
            <BoxView HeightRequest="10" Color="Transparent" />

        </VerticalStackLayout>
    </ScrollView>

</ContentPage>