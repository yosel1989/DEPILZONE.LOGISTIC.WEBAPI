using DepilZone.Api.Hubs;
using DepilZone.Application.Implement;
using DepilZone.Application.Interface;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DepilZone.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            //usuario
            //services.AddTransient<IUsuarioDat, UsuarioDat>();
            //services.AddTransient<IUsuarioDom, UsuarioDom>();
            //services.AddTransient<IUsuarioApp, UsuarioApp>();

            //services.AddTransient<IPerfilDat, PerfilDat>();
            //services.AddTransient<IPerfilDom, PerfilDom>();
            //services.AddTransient<IPerfilApp, PerfilApp>();

            //cliente
            //services.AddTransient<IProveedorDat, ProveedorDat>();
            //services.AddTransient<IProveedorDom, ProveedorDom>();
            //services.AddTransient<IProveedorApp, ProveedorApp>();

            //cita
            //services.AddTransient<ICitaDat, CitaDat>();
            //services.AddTransient<ICitaDom, CitaDom>();
            //services.AddTransient<ICitaApp, CitaApp>();

            //ficha admision
            //services.AddTransient<IFichaAdmisionDat, FichaAdmisionDat>();
            //services.AddTransient<IFichaAdmisionDom, FichaAdmisionDom>();
            //services.AddTransient<IFichaAdmisionApp, FichaAdmisionApp>();

            //maquina
            //services.AddTransient<IMaquinaDat, MaquinaDat>();
            //services.AddTransient<IMaquinaDom, MaquinaDom>();
            //services.AddTransient<IMaquinaApp, MaquinaApp>();

            //Ubicacion 
            //services.AddTransient<IUbicacionDat, UbicacionDat>();
            //services.AddTransient<IUbicacionDom, UbicacionDom>();
            //services.AddTransient<IUbicacionApp, UbicacionApp>();

            //PROVEEDORES
            services.AddTransient<IProveedorDat, ProveedorDat>();
            services.AddTransient<IProveedorDom, ProveedorDom>();
            services.AddTransient<IProveedorApp, ProveedorApp>();

            //ARTICULOS
            services.AddTransient<IArticuloDat, ArticuloDat>();
            services.AddTransient<IArticuloDom, ArticuloDom>();
            services.AddTransient<IArticuloApp, ArticuloApp>();

            //ARTICULO CATEGORIA
            services.AddTransient<IArticuloCategoriaDat, ArticuloCategoriaDat>();
            services.AddTransient<IArticuloCategoriaDom, ArticuloCategoriaDom>();
            services.AddTransient<IArticuloCategoriaApp, ArticuloCategoriaApp>();

            //UNIDAD DE MEDIDA
            services.AddTransient<IUnidadMedidaDat, UnidadMedidaDat>();
            services.AddTransient<IUnidadMedidaDom, UnidadMedidaDom>();
            services.AddTransient<IUnidadMedidaApp, UnidadMedidaApp>();

            //UBIGEO
            services.AddTransient<IUbigeoDat, UbigeoDat>();
            services.AddTransient<IUbigeoDom, UbigeoDom>();
            services.AddTransient<IUbigeoApp, UbigeoApp>();

            //AUTENTICACINO
            services.AddTransient<IAuthDat, AuthDat>();
            services.AddTransient<IAuthDom, AuthDom>();
            services.AddTransient<IAuthApp, AuthApp>();

            //ALMACEN
            services.AddTransient<IAlmacenDat, AlmacenDat>();
            services.AddTransient<IAlmacenDom, AlmacenDom>();
            services.AddTransient<IAlmacenApp, AlmacenApp>();

            //ALMACEN UBICACION
            services.AddTransient<IAlmacenUbicacionDat, AlmacenUbicacionDat>();
            services.AddTransient<IAlmacenUbicacionDom, AlmacenUbicacionDom>();
            services.AddTransient<IAlmacenUbicacionApp, AlmacenUbicacionApp>();

            //SEDE
            services.AddTransient<ISedeDat, SedeDat>();
            services.AddTransient<ISedeDom, SedeDom>();
            services.AddTransient<ISedeApp, SedeApp>();

            //TRANSACCION CLASE
            services.AddTransient<ITransaccionClaseDat, TransaccionClaseDat>();
            services.AddTransient<ITransaccionClaseDom, TransaccionClaseDom>();
            services.AddTransient<ITransaccionClaseApp, TransaccionClaseApp>();

            //TRANSACCION TIPO
            services.AddTransient<ITransaccionTipoDat, TransaccionTipoDat>();
            services.AddTransient<ITransaccionTipoDom, TransaccionTipoDom>();
            services.AddTransient<ITransaccionTipoApp, TransaccionTipoApp>();

            //TRANSACCION MOTIVO
            services.AddTransient<ITransaccionMotivoDat, TransaccionMotivoDat>();
            services.AddTransient<ITransaccionMotivoDom, TransaccionMotivoDom>();
            services.AddTransient<ITransaccionMotivoApp, TransaccionMotivoApp>();

            //TRANSACCION ESTADO
            services.AddTransient<ITransaccionEstadoDat, TransaccionEstadoDat>();
            services.AddTransient<ITransaccionEstadoDom, TransaccionEstadoDom>();
            services.AddTransient<ITransaccionEstadoApp, TransaccionEstadoApp>();

            //TRANSACCION
            services.AddTransient<ITransaccionDat, TransaccionDat>();
            services.AddTransient<ITransaccionDom, TransaccionDom>();
            services.AddTransient<ITransaccionApp, TransaccionApp>();

            //ARTICULO STOCK
            services.AddTransient<IArticuloStockDat, ArticuloStockDat>();
            services.AddTransient<IArticuloStockDom, ArticuloStockDom>();
            services.AddTransient<IArticuloStockApp, ArticuloStockApp>();

            //ARTICULO PROVEEDOR
            services.AddTransient<IArticuloProveedorDat, ArticuloProveedorDat>();
            services.AddTransient<IArticuloProveedorDom, ArticuloProveedorDom>();
            services.AddTransient<IArticuloProveedorApp, ArticuloProveedorApp>();

            //ORDEN COMPRA
            services.AddTransient<IOrdenCompraDat, OrdenCompraDat>();
            services.AddTransient<IOrdenCompraDom, OrdenCompraDom>();
            services.AddTransient<IOrdenCompraApp, OrdenCompraApp>();

            //Promocion
            //services.AddTransient<IPromocionDat, PromocionDat>();
            //services.AddTransient<IPromocionDom, PromocionDom>();
            //services.AddTransient<IPromocionApp, PromocionApp>();

            //Promocion
            //services.AddTransient<IPromocionBloqueDat, PromocionBloqueDat>();
            //services.AddTransient<IPromocionBloqueDom, PromocionBloqueDom>();
            //services.AddTransient<IPromocionBloqueApp, PromocionBloqueApp>();

            //PromocionZona 
            //services.AddTransient<IPromocionZonaDat, PromocionZonaDat>();
            //services.AddTransient<IPromocionZonaDom, PromocionZonaDom>();
            //services.AddTransient<IPromocionZonaApp, PromocionZonaApp>();

            //IPromocionPrecioApp
            //services.AddTransient<IPromocionPrecioDat, PromocionPrecioDat>();
            //services.AddTransient<IPromocionPrecioDom, PromocionPrecioDom>();
            //services.AddTransient<IPromocionPrecioApp, PromocionPrecioApp>();

            //Configuracion
            //services.AddTransient<IConfiguracionDat, ConfiguracionDat>();
            //services.AddTransient<IConfiguracionDom, ConfiguracionDom>();
            //services.AddTransient<IConfiguracionApp, ConfiguracionApp>();

            //ConfiguracionRepl
            //services.AddTransient<IConfiguracionReplDat, ConfiguracionReplDat>();
            //services.AddTransient<IConfiguracionReplDom, ConfiguracionReplDom>();
            //services.AddTransient<IConfiguracionReplApp, ConfiguracionReplApp>();

            //DOCUMENTOS
            //services.AddTransient<IDocumentoDat, DocumentoDat>();
            //services.AddTransient<IDocumentoDom, DocumentoDom>();
            //services.AddTransient<IDocumentoApp, DocumentoApp>();
            //services.AddControllers();

            //TIPOS DE DOCUMENTOS
            //services.AddTransient<IDocumentoTipoDat, DocumentoTipoDat>();
            //services.AddTransient<IDocumentoTipoDom, DocumentoTipoDom>();
            //services.AddTransient<IDocumentoTipoApp, DocumentoTipoApp>();

            //DOCUMENTO PLANTILLAS
            //services.AddTransient<IDocumentoPlantillaDat, DocumentoPlantillaDat>();
            //services.AddTransient<IDocumentoPlantillaDom, DocumentoPlantillaDom>();
            //services.AddTransient<IDocumentoPlantillaApp, DocumentoPlantillaApp>();

            //DOCUMENTOS DEL CLIENTE
            //services.AddTransient<IClienteDocumentoDat, ClienteDocumentoDat>();
            //services.AddTransient<IClienteDocumentoDom, ClienteDocumentoDom>();
            //services.AddTransient<IClienteDocumentoApp, ClienteDocumentoApp>();

            //ENVIO DE CORREO API
            //services.AddTransient<IEmailDat, EmailDat>();
            //services.AddTransient<IEmailDom, EmailDom>();
            //services.AddTransient<IEmailApp, EmailApp>();

            //TIPO DE CITA
            //services.AddTransient<ICitaTipoDat, CitaTipoDat>();
            //services.AddTransient<ICitaTipoDom, CitaTipoDom>();
            //services.AddTransient<ICitaTipoApp, CitaTipoApp>();

            //PROMOCION PLANTILLA
            //services.AddTransient<IPromocionPlantillaDat, PromocionPlantillaDat>();
            //services.AddTransient<IPromocionPlantillaDom, PromocionPlantillaDom>();
            //services.AddTransient<IPromocionPlantillaApp, PromocionPlantillaApp>();

            //Preferente
            //services.AddTransient<IPreferenteDat, PreferenteDat>();
            //services.AddTransient<IPreferenteDom, PreferenteDom>();
            //services.AddTransient<IPreferenteApp, PreferenteApp>();

            //MEDIOCONTACTO
            //services.AddTransient<IMedioContactoDat, MedioContactoDat>();
            //services.AddTransient<IMedioContactoDom, MedioContactoDom>();
            //services.AddTransient<IMedioContactoApp, MedioContactoApp>();

            //COMENTARIO
            //services.AddTransient<IComentarioDat, ComentarioDat>();
            //services.AddTransient<IComentarioDom, ComentarioDom>();
            //services.AddTransient<IComentarioApp, ComentarioApp>();

            //ESTADO
            //services.AddTransient<IEstadoDat, EstadoDat>();
            //services.AddTransient<IEstadoDom, EstadoDom>();
            //services.AddTransient<IEstadoApp, EstadoApp>();

            //Genero
            //services.AddTransient<IGeneroDat, GeneroDat>();
            //services.AddTransient<IGeneroDom, GeneroDom>();
            //services.AddTransient<IGeneroApp, GeneroApp>();

            //Documento Identidad Tipo
            //services.AddTransient<IDocumentoIdentidadTipoDat, DocumentoIdentidadTipoDat>();
            //services.AddTransient<IDocumentoIdentidadTipoDom, DocumentoIdentidadTipoDom>();
            //services.AddTransient<IDocumentoIdentidadTipoApp, DocumentoIdentidadTipoApp>();

            //Documento Identidad Tipo
            //services.AddTransient<ICitaTipoDat, CitaTipoDat>();
            //services.AddTransient<ICitaTipoDom, CitaTipoDom>();
            //services.AddTransient<ICitaTipoApp, CitaTipoApp>();

            //MAQUINASEDE
            //services.AddTransient<IMaquinaSedeDat, MaquinaSedeDat>();
            //services.AddTransient<IMaquinaSedeDom, MaquinaSedeDom>();
            //services.AddTransient<IMaquinaSedeApp, MaquinaSedeApp>();

            //CITA
            //services.AddTransient<ICitaDat, CitaDat>();
            //services.AddTransient<ICitaDom, CitaDom>();
            //services.AddTransient<ICitaApp, CitaApp>();

            //ANUNCIO
            //services.AddTransient<IAnuncioDat, AnuncioDat>();
            //services.AddTransient<IAnuncioDom, AnuncioDom>();
            //services.AddTransient<IAnuncioApp, AnuncioApp>();

            //TIPOCLIENTE
            //services.AddTransient<ITipoClienteDat, TipoClienteDat>();
            //services.AddTransient<ITipoClienteDom, TipoClienteDom>();
            //services.AddTransient<ITipoClienteApp, TipoClienteApp>();

            //CHAT
            //services.AddTransient<IChatDat, ChatDat>(); 
            //services.AddTransient<IChatDom, ChatDom>();
            //services.AddTransient<IChatApp, ChatApp>();

            //NOTAS
            //services.AddTransient<ICitaMensajeNotaDat, CitaMensajeNotaDat>();
            //services.AddTransient<ICitaMensajeNotaDom, CitaMensajeNotaDom>();
            //services.AddTransient<ICitaMensajeNotaApp, CitaMensajeNotaApp>();

            //AVISOS
            //services.AddTransient<ICitaMensajeAvisoDat, CitaMensajeAvisoDat>();
            //services.AddTransient<ICitaMensajeAvisoDom, CitaMensajeAvisoDom>();
            //services.AddTransient<ICitaMensajeAvisosApp, CitaMensajeAvisoApp>();

            //Detalle
            //services.AddTransient<ICitaMensajeDetalleDat, CitaMensajeDetalleDat>();
            //services.AddTransient<ICitaMensajeDetalleDom, CitaMensajeDetalleDom>();
            //services.AddTransient<ICitaMensajeDetalleApp, CitaMensajeDetalleApp>();

            //Seguimiento Cita
            //services.AddTransient<ICitaSeguimientoDat, CitaSeguimientoDat>();
            //services.AddTransient<ICitaSeguimientoDom, CitaSeguimientoDom>();
            //services.AddTransient<ICitaSeguimientoApp, CitaSeguimientoApp>();

            //DETALLE DE CITAS
            //services.AddTransient<ICitaDetalleDat, CitaDetalleDat>();
            //services.AddTransient<ICitaDetalleDom, CitaDetalleDom>();
            //services.AddTransient<ICitaDetalleApp, CitaDetalleApp>();

            //DETALLE DE CITAS HORARIOS
            //services.AddTransient<IDetalleCitaHorarioDat, DetalleCitaHorarioDat>();
            //services.AddTransient<IDetalleCitaHorarioDom, DetalleCitaHorarioDom>();
            //services.AddTransient<IDetalleCitaHorarioApp, DetalleCitaHorarioApp>();

            //CAJA
            //services.AddTransient<ICajaDat, CajaDat>();
            //services.AddTransient<ICajaDom, CajaDom>();
            //services.AddTransient<ICajaApp, CajaApp>();

            //VENTA
            //services.AddTransient<IVentaDat, VentaDat>();
            //services.AddTransient<IVentaDom, VentaDom>();
            //services.AddTransient<IVentaApp, VentaApp>();

            //EMPRESA
            //services.AddTransient<IEmpresaDat, EmpresaDat>();
            //services.AddTransient<IEmpresaDom, EmpresaDom>();
            //services.AddTransient<IEmpresaApp, EmpresaApp>();

            //HISTORIA CLINICA
            //services.AddTransient<IHistoriaClinicaDat, HistoriaClinicaDat>();
            //services.AddTransient<IHistoriaClinicaDom, HistoriaClinicaDom>();
            //services.AddTransient<IHistoriaClinicaApp, HistoriaClinicaApp>();

            //EVOLUCION DEL TRATAMIENTO
            //services.AddTransient<IEvolucionTratamientoDat, EvolucionTratamientoDat>();
            //services.AddTransient<IEvolucionTratamientoDom, EvolucionTratamientoDom>();
            //services.AddTransient<IEvolucionTratamientoApp, EvolucionTratamientoApp>();

            //ROLES
            //services.AddTransient<IRolesDat, RolesDat>();
            //services.AddTransient<IRolesDom, RolesDom>();
            //services.AddTransient<IRolesApp, RolesApp>();

            //MENU
            //services.AddTransient<IMenuDat, MenuDat>();
            //services.AddTransient<IMenuDom, MenuDom>();
            //services.AddTransient<IMenuApp, MenuApp>();

            //CITA ASIGNADA
            //services.AddTransient<ICitaAsignadaDat, CitaAsignadaDat>();
            //services.AddTransient<ICitaAsignadaDom, CitaAsignadaDom>();
            //services.AddTransient<ICitaAsignadaApp, CitaAsignadaApp>();

            //CLIENTE RECURRENTE
            //services.AddTransient<IClienteRecurrenteDat, ClienteRecurrenteDat>();
            //services.AddTransient<IClienteRecurrenteDom, ClienteRecurrenteDom>();
            //services.AddTransient<IClienteRecurrenteApp, ClienteRecurrenteApp>();

            //REPORTE ZONAS
            //services.AddTransient<IReporteZonasDat, ReporteZonasDat>();
            //services.AddTransient<IReporteZonasDom, ReporteZonasDom>();
            //services.AddTransient<IReporteZonasApp, ReporteZonasApp>();

            //APERTURAYCIERRE
            //services.AddTransient<IAperturaDat, AperturaDat>();
            //services.AddTransient<IAperturaDom, AperturaDom>();
            //services.AddTransient<IAperturaApp, AperturaApp>();

            //TURNO
            //services.AddTransient<ITurnoDat, TurnoDat>();
            //services.AddTransient<ITurnoDom, TurnoDom>();
            //services.AddTransient<ITurnoApp, TurnoApp>();

            //EGRESOS
            //services.AddTransient<IEgresoDat, EgresoDat>();
            //services.AddTransient<IEgresoDom, EgresoDom>();
            //services.AddTransient<IEgresoApp, EgresoApp>();

            //TIPOCOMPROBANTE
            //services.AddTransient<ITipoComprobanteDat, TipoComprobanteDat>();
            //services.AddTransient<ITipoComprobanteDom, TipoComprobanteDom>();
            //services.AddTransient<ITipoComprobanteApp, TipoComprobanteApp>();

            //LIBRORECLAMACION
            //services.AddTransient<ILibroReclamacionDat, LibroReclamacionDat>();
            //services.AddTransient<ILibroReclamacionDom, LibroReclamacionDom>();
            //services.AddTransient<ILibroReclamacionApp, LibroReclamacionApp>();
            //LIBRORECLAMACION

            //services.AddTransient<IParametroSistemaDat, ParametroSistemaDat>();
            //services.AddTransient<IParametroSistemaDom, ParametroSistemaDom>();
            //services.AddTransient<IParametroSistemaApp, ParametroSistemaApp>();
            //PATOLOGIA
            //services.AddTransient<IPatologiaDat, PatologiaDat>();
            //services.AddTransient<IPatologiaDom, PatologiaDom>();
            //services.AddTransient<IPatologiaApp, PatologiaApp>();
            //FICHAADMISION
            //services.AddTransient<IFichaAdmisionDat, FichaAdmisionDat>();
            //services.AddTransient<IFichaAdmisionDom, FichaAdmisionDom>();
            //services.AddTransient<IFichaAdmisionApp, FichaAdmisionApp>();
            //EVOLUCIONCITAMENSUAL
            //services.AddTransient<IEvolucionCitaMensualDat, EvolucionCitaMensualDat>();
            //services.AddTransient<IEvolucionCitaMensualDom, EvolucionCitaMensualDom>();
            //services.AddTransient<IEvolucionCitaMensualApp, EvolucionCitaMensualApp>();


            // EQUIPO LASER
            //services.AddTransient<IEquipoLaserDat, EquipoLaserDat>();
            //services.AddTransient<IEquipoLaserDom, EquipoLaserDom>();
            //services.AddTransient<IEquipoLaserApp, EquipoLaserApp>();

            // CITA MOTIVO ESTADO
            //services.AddTransient<ICitaEstadoMotivoDat, CitaEstadoMotivoDat>();
            //services.AddTransient<ICitaEstadoMotivoDom, CitaEstadoMotivoDom>();
            //services.AddTransient<ICitaEstadoMotivoApp, CitaEstadoMotivoApp>();

            // CITA MOTIVO
            //services.AddTransient<ICitaMotivoDat, CitaMotivoDat>();
            //services.AddTransient<ICitaMotivoDom, CitaMotivoDom>();
            //services.AddTransient<ICitaMotivoApp, CitaMotivoApp>();

            // ALTERNATIVA MEDICION
            //services.AddTransient<IAlternativaMedicionDat, AlternativaMedicionDat>();
            //services.AddTransient<IAlternativaMedicionDom, AlternativaMedicionDom>();
            //services.AddTransient<IAlternativaMedicionApp, AlternativaMedicionApp>();

            // CITA MEDICION
            //services.AddTransient<ICitaMedicionDat, CitaMedicionDat>();
            //services.AddTransient<ICitaMedicionDom, CitaMedicionDom>();
            //services.AddTransient<ICitaMedicionApp, CitaMedicionApp>();

            // TIPO MEDICION
            //services.AddTransient<ITipoMedicionDat, TipoMedicionDat>();
            //services.AddTransient<ITipoMedicionDom, TipoMedicionDom>();
            //services.AddTransient<ITipoMedicionApp, TipoMedicionApp>();

            // CLIENTE CONTRATO
            //services.AddTransient<IClienteContratoDat, ClienteContratoDat>();
            //services.AddTransient<IClienteContratoDom, ClienteContratoDom>();
            //services.AddTransient<IClienteContratoApp, ClienteContratoApp>();

            // CLIENTE ENCUESTA
            //services.AddTransient<IClienteEncuestaDat, ClienteEncuestaDat>();
            //services.AddTransient<IClienteEncuestaDom, ClienteEncuestaDom>();
            //services.AddTransient<IClienteEncuestaApp, ClienteEncuestaApp>();

            // CUPONES
            //services.AddTransient<IDescuentoDat, DescuentoDat>();
            //services.AddTransient<IDescuentoDom, DescuentoDom>();
            //services.AddTransient<IDescuentoApp, DescuentoApp>();

            // FORMULARIO ENCUESTA
            //services.AddTransient<IFormularioEncuestaDat, FormularioEncuestaDat>();
            //services.AddTransient<IFormularioEncuestaDom, FormularioEncuestaDom>();
            //services.AddTransient<IFormularioEncuestaApp, FormularioEncuestaApp>();

            //SIGNALR
            //services.AddTransient<SignalHub, SignalHub>();



            //CONTROLADORES
            //services.AddTransient<ChatController, ChatController>();
            //services.AddTransient<PreferenteController, PreferenteController>();

            //services.AddHostedService<PreferenteMonitor>();

            services.AddControllers();

            string ipCliente = "http://localhost:4207";

            //string ipCliente = "https://qa.depilzone.com.pe:3037"; //angular qa

            //string ipCliente = "https://clinic.depilzone.com.pe:3137"; //angular prod

            /*services.AddCors(options => options
                    .AddPolicy("AllowAll", p => p.SetIsOriginAllowed(isOriginAllowed: _ => true)
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials()));*/

            services.AddCors(options => options
                    .AddPolicy("AllowAll", p => p.WithOrigins(new string[] { ipCliente })
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalHub>("apiSignal");
            });
        }
    }
}

